using ASP_Event_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Repositories
{
    public interface ICustomerEventRepository
    {
        EventModel FindEvent(int id);
        IList<EventModel> FindAllEvents();
    }
}
