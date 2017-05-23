using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.DAL.Entities
{
    public class ApplicationDescription : BaseEntity
    {
        public string Name { get; set; }
        public string ImgPath { get; set; }
    }
}
