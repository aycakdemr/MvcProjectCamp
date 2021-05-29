using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("mail adı boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("konu boş geçilemez"); 
            RuleFor(x => x.Message).NotEmpty().WithMessage("mesaj boş geçilemez"); 
            RuleFor(x => x.UserName).NotEmpty().WithMessage("kullanıcı adı boş geçilemez"); 
        }
    }
}
