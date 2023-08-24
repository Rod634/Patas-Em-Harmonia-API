using FluentValidation;
using Patas.Em.Harmonia.Domain.Models;

namespace Patas.Em.Harmonia.Domain.Validators
{
    public class UserValidator : AbstractValidator<UserData>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .Length(2, 255);

            RuleFor(x => x.Email)
                .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);

            RuleFor(x => x.Phone)
                .Length(8, 13);
        }
    }
}