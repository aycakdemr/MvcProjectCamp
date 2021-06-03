using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("alıcı mail boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("konu boş geçilemez");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("mesaj boş geçilemez");
            
        }
    }
}
