using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        public String SenderMail { get; set; }
        public String ReceiverMail { get; set; }
        public String Subject { get; set; }
        public String MessageContent { get; set; }
        public DateTime MessageDate { get; set; }
        public bool Status { get; set; }
    }
}
