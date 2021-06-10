﻿using EntityLayer.Concrete;
using EntityLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
   public  interface IAbilityDal : IRepository<Ability>
    {
        List<AbilityUserDto> GetAbility();
    }
}
