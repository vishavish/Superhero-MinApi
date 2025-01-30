using FluentValidation;


namespace Application.Heroes.Commands;


public class UpdateHeroCommandValidator : AbstractValidator<UpdateHeroCommand>
{
	public UpdateHeroCommandValidator()
	{
		RuleFor(h => h.Name)
			.MaximumLength(50)
			.NotEmpty();

		RuleFor(h => h.Ability)
			.MaximumLength(50)
			.NotEmpty();

		RuleFor(h => h.PowerLevel)
			.GreaterThanOrEqualTo(1)
			.NotEmpty();
		
	}
}
