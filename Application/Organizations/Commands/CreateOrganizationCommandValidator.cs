using FluentValidation;


namespace Application.Organizations.Commands;


public class CreateOrganizationCommandValidator : AbstractValidator<CreateOrganizationCommand>
{
	public CreateOrganizationCommandValidator()
	{
		RuleFor(o => o.Name)
			.MaximumLength(50)
			.NotEmpty()
			.WithMessage("Organization name cannot empty.");
	}
}
