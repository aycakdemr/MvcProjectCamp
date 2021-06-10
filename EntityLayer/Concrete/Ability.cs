using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Ability
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public int UserId { get; set; }
    }
}
