using BusinessLayer.Abstract;
using BusinessLayer.Security.Hashing;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager :IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.WriterId == id);
        }

        public Writer GetByMail(string mail)
        {
            return _writerDal.Get(x => x.WriterMail == mail);
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public bool Login(WriterForLoginDto writer)
        {
            var userToCheck = _writerDal.Get(x => x.WriterMail == writer.Email);
            if (userToCheck == null)
            {
                return false;
            }
            if (!HashingHelper.VerifyPasswordHash(writer.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt)) 
            {
                return false;
            }
            return true;
        }
        public void Register(WriterForRegisterDto writer, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var newwriter = new Writer
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                WriterImage=writer.WriterImage,
                WriterName =writer.WriterName,
                WriterSurname =writer.WriterSurname,
                WriterMail =writer.Mail,
                WriterStatus =true,
                WriterAbout =writer.WriterAbout,
                WriterTitle =writer.WriterTitle,
                
            };
            _writerDal.Insert(newwriter);
        }
        public void WriterAdd(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
