using ASP_Event_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Repositories
{
    public interface IEventRepository
    {
        IEnumerable<EventModel> Events { get;  }
        IEnumerable<EventModel> ExpiredEvents { get;  }
        EventModel GetEventById(int eventId);
    }
}
