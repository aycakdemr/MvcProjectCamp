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
        public String AdminUserName { get; set; }
        public String AdminPassword { get; set; }
        public String AdminRole { get; set; }
    }
}
