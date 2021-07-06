using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAbilityService
    {
        List<AbilityUserDto> GetListDto();
        void Add(Ability ability);
        void Update(Ability ability);
        void Delete(Ability ability);
        Ability GetById(int id);
        List<Ability> GetList();
    }
}
