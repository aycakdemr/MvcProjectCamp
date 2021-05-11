using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category category)
        {

            _categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetById(int id)
        {
           return _categoryDal.Get(x => x.CategoryId == id);
        }

        public Category GetByName(string name)
        {
            return _categoryDal.Get(x => x.CategoryName == name);
        }

        //GenericRepository<Category> repo = new GenericRepository<Category>();

        //public List<Category> GetAll()
        //{
        //    return repo.List();
        //}
        //public void CategoryAdd(Category category)
        //{
        //    if(category.CategoryName =="" || category.CategoryName.Length <= 3)
        //    {
        //        //hata mesajı 
        //    }
        //    else
        //    {
        //        repo.Insert(category);
        //    }


        //}
        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public List<Category> StatusIsFalse()
        {
            return _categoryDal.List(x => x.CategoryStatus == false);
        }

        public List<Category> StatusIsTrue()
        {
            return _categoryDal.List(x => x.CategoryStatus == true);
        }
    }
}
