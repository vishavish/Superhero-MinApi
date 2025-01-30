using MediatR;
using Application.Common.Interfaces;

namespace Application.Heroes.Commands;


public record RemoveHeroCommand(Guid Id) : IRequest<int>;


public class RemoveHeroCommandHandler : IRequestHandler<RemoveHeroCommand, int>
{
	private readonly IApplicationDbContext _context;

	public RemoveHeroCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<int> Handle(RemoveHeroCommand cmd, CancellationToken token)
	{
		var hero = await _context.Heroes!.FindAsync(cmd.Id, token);

		// additional validation here
		 
		_context.Heroes.Remove(hero!); 


		return await _context.SaveChangesAsync(token);
	}
}
