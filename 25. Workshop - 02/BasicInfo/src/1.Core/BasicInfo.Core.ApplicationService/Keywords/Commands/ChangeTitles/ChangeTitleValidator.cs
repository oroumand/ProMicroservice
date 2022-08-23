using BasicInfo.Core.Contracts.Keywords.Commands.ChangeTitles;
using FluentValidation;
using Zamin.Extentions.Translations.Abstractions;

namespace BasicInfo.Core.ApplicationService.Keywords.Commands.ChangeTitles;

public class ChangeTitleValidator : AbstractValidator<ChangeTitle>
{
    public ChangeTitleValidator(ITranslator translator)
    {
        RuleFor(c => c.Title)
             .NotNull().WithMessage(translator["Required", "Title"])
             .MinimumLength(10).WithMessage(translator["MinimumLength", "Title", "5"])
             .MaximumLength(50).WithMessage(translator["MaximumLength", "Title", "50"]);
    }
}