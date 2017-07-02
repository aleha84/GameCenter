using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.Applications.Models
{
    public class ApplicationParticipant
    {
        public Guid ConnextionId { get; set; }
        public Vector2d ViewOffset { get; set; }
    }
}
