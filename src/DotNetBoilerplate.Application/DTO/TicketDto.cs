namespace DotNetBoilerplate.Application.DTO;

public sealed record TicketDto(
    Guid Id,
    DateTimeOffset CreatedAt);