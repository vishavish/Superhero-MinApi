using MediatR;
using Domain.Core;
using Application.Common.Interfaces;


namespace Application.Heroes.Queries;


public record GetHeroesQuery (Guid Id) : IRequest<Hero?>;


public class GetHeroesQueryHandler : IRequestHandler<GetHeroesQuery, Hero?>
{
	private readonly IApplicationDbContext _context;

	public GetHeroesQueryHandler(IApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Hero?> Handle(GetHeroesQuery qry, CancellationToken token)
	{
		return await _context.Heroes!.FindAsync(qry.Id, token);
	}
}
