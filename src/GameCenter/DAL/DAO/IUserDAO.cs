﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCenter.DAL.Entities;

namespace GameCenter.DAL.DAO
{
    public interface IUserDAO
    {
        User GetByName(string name);
    }
}
