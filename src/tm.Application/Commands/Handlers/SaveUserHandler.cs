using tm.Application.Abstractions;
using tm.Application.Exceptions;
using tm.Application.Security;
using tm.Core.Abstractions;
using tm.Core.Entities;
using tm.Core.Repositories;
using tm.Core.ValueObjects;

namespace tm.Application.Commands.Handlers;

internal sealed class SaveUserHandler : ICommandHandler<SaveUser>
{
    private readonly IUserRepository _userRepository;
    private readonly IClock _clock;

    public SaveUserHandler(IUserRepository userRepository, IClock clock)
    {
        _userRepository = userRepository;
        _clock = clock;
    }

    public async Task HandleAsync(SaveUser command)
    {
        var userId = new UserId(command.UserId);
        var email = new Email(command.Email);
        var username = new UserName(command.UserName);
        var fullName = new FullName(command.FullName);
        var role = string.IsNullOrWhiteSpace(command.Role) ? Role.User() : new Role(command.Role);

        var user = await _userRepository.GetByIdAsync(userId);

        if (user is null)
        {
            throw new UserNotFoundException(userId);
        }

        //user.UserName = username;
        //user.Email = email;
        user.FullName = fullName;
        user.Role = role;
        
        await _userRepository.AddAsync(user);
    }
}