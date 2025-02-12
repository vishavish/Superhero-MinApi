using MediatR;
using Domain.Core;
using Application.Common.Interfaces;


namespace Application.Organizations.Queries;


public record GetOrganizationQuery(Guid Id) : IRequest<Organization?>;


public class GetOrganizationQueryHandler : IRequestHandler<GetOrganizationQuery, Organization?>
{
	private readonly IApplicationDbContext _context;

	public GetOrganizationQueryHandler(IApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Organization?> Handle (GetOrganizationQuery qry, CancellationToken token)
	{
		return await _context.Organizations!.FindAsync(qry.Id, token);
	}
}
