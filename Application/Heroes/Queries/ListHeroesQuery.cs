using Microsoft.EntityFrameworkCore;
using MediatR;
using Domain.Core;
using Application.Common.Interfaces;


namespace Application.Heroes.Queries;


public record ListHeroesQuery() : IRequest<List<Hero>>;


public class ListHeroesQueryHandler : IRequestHandler<ListHeroesQuery, List<Hero>>
{
	private readonly IApplicationDbContext _context;	

	public ListHeroesQueryHandler(IApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<List<Hero>> Handle(ListHeroesQuery qry,CancellationToken token)
	{
		return await _context.Heroes.ToListAsync(token);
	}
}
