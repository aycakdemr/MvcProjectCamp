using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class WriterForRegisterDto
    {
        public int Id { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public string WriterName { get; set; }
    
        public string WriterSurname { get; set; }
     
        public string WriterImage { get; set; }
   
        public string WriterAbout { get; set; }

        public string WriterTitle { get; set; }
    }
}
