using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public String UserName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] AdminUserNameSalt { get; set; }
        public byte[] AdminUserNameHash { get; set; }
        public String AdminRole { get; set; }
    }
}
