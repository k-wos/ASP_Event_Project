using ASP_Event_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Repositories
{
    public class EventMemoryRepository : ICrudEventRepository
    {
        private Dictionary<int, EventModel> events = new Dictionary<int, EventModel>();
        private int index = 0;
        
        public EventModel AddEvent(EventModel eventModel)
        {
            eventModel.EventId = ++index;
            events.Add(eventModel.EventId, eventModel);
            return eventModel;
        }

        public void DeleteEvent(int id)
        {
            throw new NotImplementedException();
        }

        public IList<EventModel> FindAllEvents()
        {
            return events.Values.ToList();
        }

        public EventModel FindEvent(int id)
        {
            return events[id];
        }

        public void UpdateEvent(EventModel eventModel)
        {
            throw new NotImplementedException();
        }
    }
}
