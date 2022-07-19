using FluentValidation;
using Foco.API.Entities;
using System;

namespace Foco.API.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {

        public PersonValidator()
        {
            RuleFor(x => x.Tz).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(x => x.PhoneNumber).NotNull().NotEmpty().MaximumLength(12);
            RuleFor(x => x.DateOfBirth).NotNull().NotEmpty()
                .GreaterThan(p => new DateTime(1900, 1, 1))
                .LessThan(p => new DateTime(2000, 12, 31));
            RuleFor(x => x.FirstName).NotNull().NotEmpty().MaximumLength(20);
            RuleFor(x => x.LastName).NotNull().NotEmpty().MaximumLength(20);
        }
    }
}
