using FluentValidation;
using Domain.Core;


namespace Application.Organizations.Commands;


public class CreateOrganizationCommandValidator : AbstractValidator<Organization>
{
	public CreateOrganizationCommandValidator()
	{
		RuleFor(o => o.Name)
			.MaximumLength(50)
			.NotEmpty()
			.WithMessage("Organization name cannot empty.");
	}
}
