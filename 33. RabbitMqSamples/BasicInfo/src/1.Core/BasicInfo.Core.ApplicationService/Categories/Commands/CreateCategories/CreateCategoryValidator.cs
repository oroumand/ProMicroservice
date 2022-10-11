using BasicInfo.Core.Contracts.Keywords.Commands.CreateKeywords;
using FluentValidation;
using Zamin.Extentions.Translations.Abstractions;

namespace BasicInfo.Core.ApplicationService.Keywords.Commands.CreateKeywords;

public class CreateCategoryValidator : AbstractValidator<CreateCategory>
{
    public CreateCategoryValidator(ITranslator translator)
    {
        RuleFor(c => c.Title)
             .NotNull().WithMessage(translator["Required", "Title"])
             .MinimumLength(2).WithMessage(translator["MinimumLength", "Title", "2"])
             .MaximumLength(50).WithMessage(translator["MaximumLength", "Title", "50"]);

        RuleFor(c => c.Name)
         .NotNull().WithMessage(translator["Required", "Name"])
         .MinimumLength(2).WithMessage(translator["MinimumLength", "Name", "2"])
         .MaximumLength(50).WithMessage(translator["MaximumLength", "Name", "50"]);
    }
}