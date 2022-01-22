using ASP_Event_Project.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EventRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public IEnumerable<EventModel> Events => _applicationDbContext.Events.Include(c => c.Category);

        public IEnumerable<EventModel> ExpiredEvents => _applicationDbContext.Events.Where(e => e.Expired).Include(c => c.Category);

        public EventModel GetEventById(int eventId) => _applicationDbContext.Events.FirstOrDefault(e => e.EventId == eventId);
        
    }
}
