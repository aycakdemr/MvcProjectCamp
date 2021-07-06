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
    public class AbilityManager : IAbilityService
    {
        IAbilityDal _abilityDal;

        public AbilityManager(IAbilityDal abilityDal)
        {
            _abilityDal = abilityDal;
        }

        public void Add(Ability ability)
        {
            _abilityDal.Insert(ability);
        }

        public List<AbilityUserDto> GetListDto()
        {
            return _abilityDal.GetAbility();
        }
        public List<Ability> GetList()
        {
            return _abilityDal.List();
        }

        public void Delete(Ability ability)
        {
            _abilityDal.Delete(ability);
        }
        public void Update(Ability ability)
        {
            ability.UserId = 1;
            _abilityDal.Update(ability);
        }
        public Ability GetById(int id)
        {
            return _abilityDal.Get(x => x.Id == id);
        }
    }
}
