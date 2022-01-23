using ASP_Event_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Repositories
{
    public interface ICrudEventRepository
    {
        EventModel FindEvent(int id);
        EventModel AddEvent(EventModel eventModel);
        EventModel DeleteEvent(int id);
        void UpdateEvent(EventModel eventModel);
        IList<EventModel> FindAllEvents();
    }
}
