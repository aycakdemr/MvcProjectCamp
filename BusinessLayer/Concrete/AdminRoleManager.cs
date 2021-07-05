using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminRoleManager : IAdminRoleService
    {
        EfAdminRoleDal adm = new EfAdminRoleDal();

        public AdminRoleManager(EfAdminRoleDal adm)
        {
            this.adm = adm;
        }

        public List<AdminRole> GetList()
        {
            return adm.List();
        }
    }
}
