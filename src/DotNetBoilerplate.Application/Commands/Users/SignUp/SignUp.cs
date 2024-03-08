using DotNetBoilerplate.Shared.Abstractions.Commands;

namespace DotNetBoilerplate.Application.Commands.Users.SignUp;

public record SignUp(Guid UserId, string Email, string Username, string Password) : ICommand;