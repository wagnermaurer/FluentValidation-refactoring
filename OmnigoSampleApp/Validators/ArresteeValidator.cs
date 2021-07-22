using FluentValidation;
using OmnigoSampleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OmnigoSampleApp.Validators
{
    public class ArresteeValidator : AbstractValidator<Arrestee>
    {
        public ArresteeValidator(Offense o)
        {
            if (!o.CanBeAppliedToAMinor)
                RuleFor(arrestee => arrestee.Age).GreaterThanOrEqualTo(18).WithMessage("A minor cannot be arrested for this time.");
        }
    }
}
