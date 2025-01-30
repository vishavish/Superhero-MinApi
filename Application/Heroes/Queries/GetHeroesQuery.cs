using MediatR;
using Domain.Core;
using Application.Common.Interfaces;


namespace Application.Heroes.Queries;


public record GetHeroQuery (Guid Id) : IRequest<Hero?>;


public class GetHeroesQueryHandler : IRequestHandler<GetHeroQuery, Hero?>
{
	private readonly IApplicationDbContext _context;

	public GetHeroesQueryHandler(IApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<Hero?> Handle(GetHeroQuery qry, CancellationToken token)
	{
		return await _context.Heroes!.FindAsync(qry.Id, token);
	}
}
