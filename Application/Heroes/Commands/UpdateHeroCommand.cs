using MediatR;
using Application.Common.Interfaces;


namespace Application.Heroes.Commands;


public record UpdateHeroCommand (
	Guid Id,
	string Name,
	string Ability,
	int PowerLevel
) : IRequest<int>;


public class UpdateHeroCommandHandler : IRequestHandler<UpdateHeroCommand, int>
{
	private readonly IApplicationDbContext _context;

	public UpdateHeroCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}


	public async Task<int> Handle(UpdateHeroCommand cmd, CancellationToken token)
	{
		var hero = await _context.Heroes!.FindAsync(cmd.Id, token);

		// additional validation here

		hero!.Update(cmd.Name, cmd.Ability, cmd.PowerLevel);

		_context.Heroes.Update(hero);

		return await _context.SaveChangesAsync(token);
	}
}
