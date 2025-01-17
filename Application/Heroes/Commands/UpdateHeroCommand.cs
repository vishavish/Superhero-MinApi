using MediatR;
using Application.Common.Interfaces;


namespace Application.Heroes.Commands;


public record UpdateHeroCommand (
	Guid Id,
	string Name,
	string Ability,
	int PowerLevel
) : IRequest;


public class UpdateHeroCommandHandler : IRequestHandler<UpdateHeroCommand>
{
	private readonly IApplicationDbContext _context;

	public UpdateHeroCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}


	public async Task Handle(UpdateHeroCommand cmd, CancellationToken token)
	{
		var hero = await _context.Heroes!.FindAsync(cmd.Id, token);

		// additional validation here

		hero!.Update(cmd.Name, cmd.Ability, cmd.PowerLevel);

		_context.Heroes.Update(hero);

		await _context.SaveChangesAsync(token);
	}
}
