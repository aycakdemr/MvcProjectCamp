using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator :AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("kategori adı boş geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("açıklama boş geçilemez");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("lütfen 20 karakterden fazla değer girişi yapmayın");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("en az üç karakter girişi yapın");
        }
    }
}
