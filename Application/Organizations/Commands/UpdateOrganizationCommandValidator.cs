using FluentValidation;


namespace Application.Organizations.Commands;


public class UpdateOrganizationCommandValidator : AbstractValidator<UpdateOrganizationCommand>
{
	public UpdateOrganizationCommandValidator()
	{
		RuleFor(o => o.Name)
			.MaximumLength(20)
			.NotEmpty()
			.WithMessage("Organization name cannot be empty");
	}
}
