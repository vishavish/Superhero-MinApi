using MediatR;
using Domain.Core;
using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Applicatiion.Organizations.Queries;


public record ListOrganizationsQuery() : IRequest<List<Organization>>;


public class ListOrganizationQueryHandler : IRequestHandler<ListOrganizationsQuery, List<Organization>>
{
	private readonly IApplicationDbContext _context;

	public ListOrganizationQueryHandler(IApplicationDbContext context)
	{
		_context = context;
	}


	public async Task<List<Organization>> Handle(ListOrganizationsQuery qry, CancellationToken token)
	{
		return await _context.Organizations!.ToListAsync(token);
	}
}
