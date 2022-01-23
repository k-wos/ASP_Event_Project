using ASP_Event_Project.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Repositories
{
    public class CrudEventRepository : ICrudEventRepository
    {
        private ApplicationDbContext _context;
        public CrudEventRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public EventModel AddEvent(EventModel eventModel)
        {
            var entity = _context.Events.Add(eventModel).Entity;
            _context.SaveChanges();
            return entity;
        }

        public void DeleteEvent(int id)
        {
             _context.Events.Remove(_context.Events.Find(id));
            _context.SaveChanges();
            
        }


        public EventModel FindEvent(int id)
        {
            return _context.Events.Find(id);
        }

        public void UpdateEvent(EventModel eventModel)
        {
            _context.Entry(eventModel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
        public IList<EventModel> FindAllEvents()
        {
            return _context.Events.ToList();
        }
    }
}
