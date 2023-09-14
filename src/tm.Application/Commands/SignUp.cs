using tm.Application.Abstractions;

namespace tm.Application.Commands;

public record SignUp(Guid UserId, string Email, string UserName, string Password, string FullName, string Role) : ICommand;
