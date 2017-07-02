using GameCenter.Applications.Models;
using GameCenter.Models;

namespace GameCenter.Applications
{
    public interface IApplication
    {
        ApplicationParticipant[] Participants { get; set; }
        ApplicationParticipant Creator { get; set; }
        ApplicationDescriptionModel Description { get; set; }
        void Process();
    }
}
