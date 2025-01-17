using MediatR;
using Application.Common.Interfaces;


namespace Application.Organizations.Commands;


public record RemoveOrganizationCommand(Guid Id) : IRequest;


public class RemoveOrganizationCommandHandler : IRequestHandler<RemoveOrganizationCommand>
{
	private readonly IApplicationDbContext _context;

	public RemoveOrganizationCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}


	public async Task Handle(RemoveOrganizationCommand cmd, CancellationToken token)
	{
		var org = await _context.Organizations!.FindAsync(cmd.Id, token);

		// additional validation here
		 
		_context.Organizations.Remove(org!);


		await _context.SaveChangesAsync(token);
	}
}
