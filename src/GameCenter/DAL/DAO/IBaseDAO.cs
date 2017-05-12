using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCenter.DAL.Entities;

namespace GameCenter.DAL.DAO
{
    public interface IBaseDAO<out TBaseEntity> where TBaseEntity : BaseEntity
    {
        TBaseEntity GetById(int id);
        IEnumerable<TBaseEntity> GetAll();
    }
}
