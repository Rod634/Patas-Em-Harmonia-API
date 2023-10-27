using FluentValidation;
using Patas.Em.Harmonia.Domain.Models.DTO;

namespace Patas.Em.Harmonia.Domain.Validators
{
    public class AnimalValidator : AbstractValidator<CreateAnimalDto>
    {
        public AnimalValidator()
        {
            RuleFor(x => x.Name)
                .NotNull();

            RuleFor(x => x.Age)
                .GreaterThan(0);

            RuleFor(x => x.Race)
                .NotNull();

            RuleFor(x => x.Species)
                .NotNull();

            RuleFor(x => x.Gender)
                .NotNull();

            RuleFor(x => x.Errant)
               .NotNull();

        }
    }
}
