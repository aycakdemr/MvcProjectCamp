using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();
        List<CategoryChartDto> CategoryChartList();
        void CategoryAdd(Category category);
        Category GetById(int id);
        Category GetByName(string name);
        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
        List<Category> StatusIsTrue();
        List<Category> StatusIsFalse();
    }
}
