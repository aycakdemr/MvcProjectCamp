using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public List<Heading> Get(int id)
        {
            return _headingDal.List(x => x.CategoryId == id);
        }
        public List<Heading> CategoryNameWithTheMostTitles()
        {
            return _headingDal.List().GroupBy(x => x.CategoryId).Select(s => new Heading
            {
                CategoryId = s.LastOrDefault().CategoryId,
                Category = s.LastOrDefault().Category,
                Contents = s.LastOrDefault().Contents,
                HeadingDate = s.LastOrDefault().HeadingDate,
                HeadingId = s.LastOrDefault().HeadingId,
                HeadingName = s.LastOrDefault().HeadingName,
                writer = s.LastOrDefault().writer,
                WriterId = s.LastOrDefault().WriterId

            }).Take(1).OrderByDescending(o => o.CategoryId).ToList();
            
               

        }
    }
}
