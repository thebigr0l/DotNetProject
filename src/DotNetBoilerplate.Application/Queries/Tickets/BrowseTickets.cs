using DotNetBoilerplate.Application.DTO;
using DotNetBoilerplate.Shared.Abstractions.Queries;

namespace DotNetBoilerplate.Application.Queries.Tickets;

public class BrowseTickets : IQuery<IEnumerable<TicketDto>>;