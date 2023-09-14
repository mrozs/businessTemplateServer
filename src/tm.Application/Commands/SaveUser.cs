using tm.Application.Abstractions;

namespace tm.Application.Commands;

public record SaveUser(Guid UserId, string Email, string UserName, string FullName, string Role) : ICommand;
