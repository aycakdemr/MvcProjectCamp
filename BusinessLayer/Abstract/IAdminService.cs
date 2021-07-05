using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetList();
        bool Login(AdminForLoginDto admin);
        void AdminAdd(AdminForRegisterDto adminregister, string password);
        Admin GetById(int id);
        Admin GetByName(String name);
        Admin GetByMail(String mail);
        void ChangeRole(int id, String role);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
    }
}
