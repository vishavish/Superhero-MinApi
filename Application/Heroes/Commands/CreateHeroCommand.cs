using MediatR;
using Domain.Core;
using Application.Common.Interfaces;


namespace Application.Heroes.Commands;


public record CreateHeroCommand (
	string Name,
	string Ability,
	int PowerLevel
) : IRequest<int>;


public class CreateHeroCommandHandler : IRequestHandler<CreateHeroCommand, int>
{
	private readonly IApplicationDbContext _context;

	public CreateHeroCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<int> Handle(CreateHeroCommand cmd, CancellationToken token)
	{
		var hero = new Hero
		{
			Name = cmd.Name,
			Ability = cmd.Ability,
			PowerLevel = cmd.PowerLevel
		};


		_context.Heroes.Add(hero);

		return await _context.SaveChangesAsync(token);
	}
}
