using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.Models
{
    public class ApplicationDescriptionModel : BaseModel
    {
        public string Name { get; set; }
        public string ImgPath { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public bool IsMultiplayer { get; set; }
        public int MaxPlayers { get; set; }
    }
}
