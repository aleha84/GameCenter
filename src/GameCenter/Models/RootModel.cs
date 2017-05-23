using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.Models
{
    public class RootModel
    {
        public UserModel User { get; set; }
        public string Message { get; set; }
        public IEnumerable<ApplicationDescriptionModel> Applications { get; set; }
    }
}
