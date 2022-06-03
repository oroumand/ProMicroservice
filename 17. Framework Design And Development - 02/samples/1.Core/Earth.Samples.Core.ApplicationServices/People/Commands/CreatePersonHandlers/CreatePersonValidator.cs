using Earth.Samples.Core.Contracts.People.Commands;
using Earth.Samples.Core.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zamin.Extentions.Translations.Abstractions;

namespace Earth.Samples.Core.ApplicationServices.People.Commands.CreatePersonHandlers;

public class CreatePersonValidator:AbstractValidator<CreatePerson>
{
    public CreatePersonValidator(ITranslator translator)
    {
        RuleFor(c => c.FirstName).NotEmpty().WithMessage(translator[Messages.InvalidNullValue, Messages.FirstName]);
        RuleFor(c => c.LastName).NotEmpty().WithMessage(translator[Messages.InvalidNullValue, Messages.FirstName]);
    }
}