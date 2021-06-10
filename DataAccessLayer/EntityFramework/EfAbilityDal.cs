using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAbilityDal : GenericRepository<Ability>, IAbilityDal
    {
        public List<AbilityUserDto> GetAbility()
        {
            using (Context context = new Context())
            {
                var result = from ability in context.Abilities
                             join user in context.Users
                             on ability.UserId equals user.Id

                             select new AbilityUserDto
                             {
                                 AbilityName = ability.Name,
                                 Degree = ability.Degree,
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Title = user.Title
                             };
                return result.ToList();
            }
        }

    }
}
