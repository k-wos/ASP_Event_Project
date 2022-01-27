using ASP_Event_Project.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Repositories
{
    public class CustomerEventRepository : ICustomerEventRepository
    {
        private ApplicationDbContext _context;
        public CustomerEventRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public EventModel FindEvent(int id)
        {
            return _context.Events.Find(id);
        }
        public IList<EventModel> FindAllEvents()
        {
            return _context.Events.ToList();
        }
    }
}
