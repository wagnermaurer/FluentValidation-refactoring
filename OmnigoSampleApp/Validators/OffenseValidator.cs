using FluentValidation;
using OmnigoSampleApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OmnigoSampleApp.Validators
{
    public class OffenseValidator : AbstractValidator<Offense>
    {
        public OffenseValidator()
        {
            RuleFor(x => x.Arrestees).NotEmpty().When(o => o.OffenseId == 1).When(o => !o.WasAttempted);
            RuleForEach(x => x.Arrestees).SetValidator((offense, arrestee) => new ArresteeValidator(offense));
        }
    }
}
