using FluentValidation;
using Patas.Em.Harmonia.Domain.Models;

namespace Patas.Em.Harmonia.Domain.Validators
{
    public class NgoValidator : AbstractValidator<NgoData>
    {
        public NgoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .Length(2, 255);

            RuleFor(x => x.Email)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);

            RuleFor(x => x.Phone)
                .Length(8, 13);

            RuleFor(x => x.Services)
                .NotNull()
                .Length(2, 1000);

            RuleFor(x => x.Address)
                .Length(2, 255);

            RuleFor(x => x.Address)
                .Length(2, 255);

            RuleFor(x => x.LatitudeLongitude)
                .Length(15, 600);

            RuleFor(x => x.Neighborhood)
                .Length(2, 255);
        }
    }
}