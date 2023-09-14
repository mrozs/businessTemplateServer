using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using tm.Application.Abstractions;
using tm.Application.Commands;
using tm.Application.DTO;
using tm.Application.Queries;
using tm.Application.Security;

namespace tm.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IQueryHandler<GetUsers, IEnumerable<UserDTO>> _getUsersHandler;
        private readonly IQueryHandler<GetUser, UserDTO> _getUserHandler;
        private readonly ICommandHandler<SignUp> _signUpHandler;
        private readonly ICommandHandler<SignIn> _signInHandler;
        private readonly ITokenStorage _tokenStorage;

        public UsersController(ICommandHandler<SignUp> signUpHandler,
            ICommandHandler<SignIn> signInHandler,
            IQueryHandler<GetUsers, IEnumerable<UserDTO>> getUsersHandler,
            IQueryHandler<GetUser, UserDTO> getUserHandler,
            ITokenStorage tokenStorage)
        {
            _signUpHandler = signUpHandler;
            _signInHandler = signInHandler;
            _getUsersHandler = getUsersHandler;
            _getUserHandler = getUserHandler;
            _tokenStorage = tokenStorage;
        }

        //[Authorize(Policy = "is-admin")]
        [HttpGet("{userId:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDTO>> Get(Guid userId)
        {
            var user = await _getUserHandler.HandleAsync(new GetUser { UserId = userId });
            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet("me")]
        public async Task<ActionResult<UserDTO>> Get()
        {
            if (string.IsNullOrWhiteSpace(User.Identity?.Name))
            {
                return NotFound();
            }

            var userId = Guid.Parse(User.Identity?.Name);
            var user = await _getUserHandler.HandleAsync(new GetUser { UserId = userId });

            return user;
        }

        [HttpGet]
        [SwaggerOperation("Get list of all the users")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [Authorize(Policy = "is-admin")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get([FromQuery] GetUsers query)
            => Ok(await _getUsersHandler.HandleAsync(query));

        [HttpPost]
        [SwaggerOperation("Create the user account")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Post(SignUp command)
        {
            command = command with { UserId = Guid.NewGuid() };
            await _signUpHandler.HandleAsync(command);
            return CreatedAtAction(nameof(Get), new { command.UserId }, null);
        }

        [HttpPost("sign-in")]
        [SwaggerOperation("Sign in the user and return the JSON Web Token")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<JwtDTO>> Post(SignIn command)
        {
            await _signInHandler.HandleAsync(command);
            var jwt = _tokenStorage.Get();
            return jwt;
        }

        [HttpPut]
        public void Put(UserDTO user)
        {
        }
    }
}
