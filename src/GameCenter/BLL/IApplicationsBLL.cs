using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameCenter.Models;

namespace GameCenter.BLL
{
    public interface IApplicationsBLL
    {
        IEnumerable<ApplicationDescriptionModel> GetAll();
    }
}
