using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("yazar adı boş geçilemez");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("yazar soyadı boş geçilemez");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("yazar ünvan boş geçilemez");
            RuleFor(x => x.WriterAbout).Must(ContainsA).WithMessage("hakkımda kısmı a karakteri içermeli");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("en az iki karakter girişi yapın");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("en fazla 50 karakter girişi");
        }
        private bool ContainsA(string arg)
        {
            return arg.Contains("a");
        }
    }
}
