using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Image
    {
        [Key]
        public int Id { get; set; }
        public String ImageName { get; set; }
        public String ImagePath { get; set; }
    }
}
