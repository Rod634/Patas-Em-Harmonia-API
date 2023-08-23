using FluentValidation;
using Patas.Em.Harmonia.Domain.Models;

namespace Patas.Em.Harmonia.Domain.Validators
{
    public class AnimalValidator : AbstractValidator<AnimalData>
    {
        public AnimalValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .Length(2, 255);

            RuleFor(x => x.Age)
                .GreaterThan(0);

            RuleFor(x => x.IdUser)
             .GreaterThan(0);

            RuleFor(x => x.Race)
                .NotNull()
                .Length(2, 255);

            RuleFor(x => x.Species)
                .NotNull()
                .Length(2, 255);

            RuleFor(x => x.Gender)
                .NotNull()
                .Length(2, 255);

            RuleFor(x => x.Errant)
               .NotNull();

            RuleFor(x => x.Neighborhood)
               .NotNull()
               .Length(2, 255);

           RuleFor(x => x.Status)
                .NotNull()
                .Length(2, 255);
        }
    }
}
