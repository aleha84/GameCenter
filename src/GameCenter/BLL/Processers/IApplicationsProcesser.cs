using GameCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.BLL.Processers
{
    public interface IApplicationsProcesser
    {
        void Add(ApplicationDescriptionModel application);
    }
}
