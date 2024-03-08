using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Commands.Users.SignIn;

public record SignIn(string Email, string Password) : ICommand;