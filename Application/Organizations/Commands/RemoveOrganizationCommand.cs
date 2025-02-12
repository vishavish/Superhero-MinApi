using MediatR;
using Application.Common.Interfaces;


namespace Application.Organizations.Commands;


public record RemoveOrganizationCommand(Guid Id) : IRequest<int>;


public class RemoveOrganizationCommandHandler : IRequestHandler<RemoveOrganizationCommand, int>
{
	private readonly IApplicationDbContext _context;

	public RemoveOrganizationCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}


	public async Task<int> Handle(RemoveOrganizationCommand cmd, CancellationToken token)
	{
		var org = await _context.Organizations!.FindAsync(cmd.Id, token);

		// additional validation here
		 
		_context.Organizations.Remove(org!);


		return await _context.SaveChangesAsync(token);
	}
}
