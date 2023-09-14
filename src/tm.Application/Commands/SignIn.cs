using tm.Application.Abstractions;

namespace tm.Application.Commands;

public record SignIn(string Email, string Password) : ICommand;
