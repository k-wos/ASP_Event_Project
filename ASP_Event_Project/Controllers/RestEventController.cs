using ASP_Event_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Controllers
{
    [Route("/api/events")]
    [ApiController]
    public class RestEventController : ControllerBase
    {
        private ApplicationDbContext _context;
        public RestEventController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public EventModel AddEvent([FromBody] EventModel eventModel)
        {
            var entity = _context.Events.Add(eventModel).Entity;
            _context.SaveChanges();
            return entity;
        }
        [HttpGet]
        public IList<EventModel> GetEvent()
        {
            return _context.Events.ToList();
        }
        [HttpPut("{id}")]
        public ActionResult<EventModel> EditEvent(int id, [FromBody] EventModel eventModel)
        {
            var a = _context.Events.Where(e => e.EventId == id).FirstOrDefault();

            if(a!= null)
            {
                a.Name = eventModel.Name;
                a.AgeRange = eventModel.AgeRange;
                a.Place = eventModel.Place;
                a.Description = eventModel.Description;
                a.Price = eventModel.Price;
                a.EventDate = eventModel.EventDate;
                a.CategoryId = eventModel.CategoryId;
                _context.SaveChanges();
            }
            else
            {
                return NotFound();
            }
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public EventModel DeleteEvent(int id)
        {
            var events = _context.Events.Where(e => e.EventId == id).First();
            _context.Remove(events);
            _context.SaveChanges();
            return events;
        }
        
    }
}
