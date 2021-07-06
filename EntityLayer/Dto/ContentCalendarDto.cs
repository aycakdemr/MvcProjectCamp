using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class ContentCalendarDto
    {
        //public string ContentName { get; set; }
        //public String ContentDate { get; set; }
        public String title { get; set; }

        public DateTime start { get; set; }

        public DateTime end { get; set; }

        public bool allDay { get; set; }

    }
}
