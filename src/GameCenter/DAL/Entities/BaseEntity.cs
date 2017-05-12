using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GameCenter.DAL.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public object Clone()
        {
            var type = GetType();

            var cloned = Activator.CreateInstance(type);
            foreach (var prop in type.GetProperties())
            {
                prop.SetValue(cloned, prop.GetValue(this));
            }

            return cloned;
        }
    }
}
