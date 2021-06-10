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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AdminAdd(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminDal.Update(admin);
        }

        public Admin GetById(int id)
        {
            return _adminDal.Get(x => x.Id == id);
        }
        public bool Login(AdminForLoginDto admin)
        {
            var userToCheck = GetById(admin.Id);
            if (userToCheck == null)
            {
                return false;
            }
            if (!HashingHelper.VerifyPasswordHash(admin.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt)&&
                !HashingHelper.VerifyMailHash(admin.Email,userToCheck.AdminUserNameHash,userToCheck.AdminUserNameSalt))
            {
                return false;
            }
            return true;
        }
        public bool Register(AdminForRegisterDto adminregister, string password)
        {
            byte[] passwordHash, passwordSalt, mailHash ,mailSalt ;
            HashingHelper.CreateMailHash(adminregister.Mail,out mailHash,out mailSalt);
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var admin = new Admin
            {
                AdminRole = adminregister.AdminRole,
                PasswordHash = passwordHash,
                PasswordSalt =passwordSalt,
                AdminUserNameHash = mailHash,
                AdminUserNameSalt =mailSalt,
                UserName = adminregister.UserName
                
            };
            _adminDal.Insert(admin);
            return true;
        }
        public List<Admin> GetList()
        {
            return _adminDal.List();
        }

        public Admin GetByName(String name)
        {
            return _adminDal.Get(x => x.UserName == name);
        }
    }
}
