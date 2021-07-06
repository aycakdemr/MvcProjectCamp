using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            this._contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _contentDal.Insert(content);
        }

        public List<ContentChartDto> ContentChart()
        {
            List<ContentChartDto> chd = new List<ContentChartDto>();
            foreach (var item in GetList())
            {
                chd.Add(new ContentChartDto()
                {

                    ContentName = item.ContentValue,
                    ContentCount = GetList().Count
                });
            }
            return chd;
        }

        public void ContentDelete(Content content)
        {
            _contentDal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.Update(content);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(x => x.ContentId == id);
        }

        public List<ContentCalendarDto> GetCalendar()
        {
            List<ContentCalendarDto> chd = new List<ContentCalendarDto>();
            //foreach (var item in GetList())
            //{
            //    chd.Add(new ContentCalendarDto()
            //    {

            //        ContentName = item.ContentValue,
            //        ContentDate = item.ContentDate.ToString()
            //    }); ;
            //}
            return chd;
        }

        public List<Content> GetList()
        {
            return _contentDal.List();
        }

        public List<Content> GetList(string p)
        {
            var values = _contentDal.List(x => x.ContentValue.Contains(p));
            if(p == null)
            {
                return GetList();
            }
            return values;
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDal.List(x => x.HeadingId == id);
        }

        public List<Content> GetListByWriterId(int id)
        {
            return _contentDal.List(x => x.WriterId == id);
        }
    }
}
