using MediatR;
using Domain.Core;
using Application.Common.Interfaces;


namespace Application.Organizations.Commands;


public record CreateOrganizationCommand(
	string Name
) : IRequest<int>;


public class CreateOrganizationCommandHandler : IRequestHandler<CreateOrganizationCommand, int>
{
	private readonly IApplicationDbContext _context;

	public CreateOrganizationCommandHandler(IApplicationDbContext context) 
	{
		_context = context;
	}


	public async Task<int> Handle(CreateOrganizationCommand cmd, CancellationToken token)
	{
		var newOrg = new Organization()
		{
			Name = cmd.Name
		};

		_context.Organizations!.Add(newOrg);

		return await _context.SaveChangesAsync(token);
	}
}
