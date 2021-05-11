using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dto
{
    public class Statistics
    {
        public int CategoriesCount { get; set; }
        public int SoftwareHeaderCount { get; set; }
        public int WritersCount { get; set; }
        public String CategoryNameWithTheMostTitles  { get; set; }
        public int Difference { get; set; }
    }
}
