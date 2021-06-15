using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        bool Login(WriterForLoginDto writer);
        bool Register(WriterForRegisterDto writer,string password);
        void WriterAdd(Writer writer);
        Writer GetById(int id);
        Writer GetByMail(string mail);
        void WriterDelete(Writer writer);
        void WriterUpdate(Writer writer);
    }
}
