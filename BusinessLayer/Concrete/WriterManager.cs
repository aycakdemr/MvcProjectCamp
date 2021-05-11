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
    public class WriterManager :IWriterService
    {
        IWriterDal _writerDao;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDao = writerDal;
        }

        public List<Writer> GetList()
        {
            return _writerDao.List(x=>x.WriterName.Contains("a"));
        }
    }
}
