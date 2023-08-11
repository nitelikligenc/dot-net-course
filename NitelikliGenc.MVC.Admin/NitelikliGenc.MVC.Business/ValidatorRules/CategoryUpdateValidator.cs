using FluentValidation;
using NitelikliGenc.MVC.Entities.Entities;

namespace NitelikliGenc.MVC.Business.ValidatorRules;

public class CategoryUpdateValidator: AbstractValidator<Category>
{
    public CategoryUpdateValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("This field must be required.");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanını boi geçemezsiniz.");
        RuleFor(x => x.Name).MinimumLength(2).WithMessage("Bu alan en az 2 karakter olmalı.");
        RuleFor(x => x.Name).MaximumLength(100).WithMessage("Bu alan en fazla 100 karakter olmalı.");
        RuleFor(x => x.Description).MinimumLength(10).WithMessage("Bu alan en az 10 karakter olmalı.");
        RuleFor(x => x.Description).MaximumLength(500).WithMessage("Bu alan en fazla 500 karakter olmalı.");
    }
}