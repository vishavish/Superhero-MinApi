using MediatR;
using Application.Common.Interfaces;


namespace Application.Organizations.Commands;


public record UpdateOrganizationCommand(Guid Id, string Name) : IRequest;


public class UpdateOrganizationCommandHandler : IRequestHandler<UpdateOrganizationCommand>
{
	private readonly IApplicationDbContext _context;

	public UpdateOrganizationCommandHandler(IApplicationDbContext context)
	{
		_context = context;
	}

	public async Task Handle(UpdateOrganizationCommand cmd, CancellationToken token)
	{
		var org = await _context.Organizations!.FindAsync(cmd.Id, token);

		// additional validation here
		
		org!.Update(cmd.Name);

		_context.Organizations.Update(org);

		await _context.SaveChangesAsync(token);
	}
}
