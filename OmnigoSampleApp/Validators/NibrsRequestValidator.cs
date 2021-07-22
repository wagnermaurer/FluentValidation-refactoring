using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using FluentValidation;



using OmnigoSampleApp.Models;

namespace OmnigoSampleApp.Validators
{
    public class NibrsRequestValidator : AbstractValidator<NibrsRequest>
    {
        public NibrsRequestValidator()
        {
            RuleForEach(x => x.Offenses).SetValidator((list, offense) => new OffenseValidator());
        }
    }
}
