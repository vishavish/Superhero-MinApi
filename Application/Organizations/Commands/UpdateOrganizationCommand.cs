using MediatR;
using Application.Common.Interfaces;


namespace Application.Organizations.Commands;


public record UpdateOrganizationCommand(Guid Id, string Name) : IRequest<int>;


public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand, int>
{
	private readonly IApplicationDbContext _context;

	public UpdateOrganizationCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}

	public async Task<int> Handle(UpdateOrganizationCommand cmd, CancellationToken token)
	{
		var org = await _context.Organizations!.FindAsync(cmd.Id, token);

		// additional validation here
		
		org!.Update(cmd.Name);

		_context.Organizations.Update(org);

		return await _context.SaveChangesAsync(token);
	}
}
