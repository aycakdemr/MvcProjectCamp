using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox();
        List<Message> GetListSendInbox();
        void MessageAdd(Message message);
        Message GetById(int id);
        void WriterDelete(Message message);
        void WriterUpdate(Message message);
    }
}
