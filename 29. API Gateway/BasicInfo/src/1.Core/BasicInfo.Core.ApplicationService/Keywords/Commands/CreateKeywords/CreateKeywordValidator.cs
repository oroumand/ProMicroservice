using BasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;
using FluentValidation;
using Zamin.Extentions.Translations.Abstractions;

namespace BasicInfo.Core.ApplicationService.Keywords.Commands.CreateKeywords;

public class CreateKeywordValidator : AbstractValidator<CreateKeyword>
{
    public CreateKeywordValidator(ITranslator translator)
    {
        RuleFor(c => c.Title)
             .NotNull().WithMessage(translator["Required", "Title"])
             .MinimumLength(10).WithMessage(translator["MinimumLength", "Title", "5"])
             .MaximumLength(50).WithMessage(translator["MaximumLength", "Title", "50"]);
    }
}