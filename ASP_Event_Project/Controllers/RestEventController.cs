using ASP_Event_Project.Models;
using ASP_Event_Project.Repositories;
using Microsoft.AspNetCore.Authorization;
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
        private ICrudEventRepository _context;
        public RestEventController(ICrudEventRepository context)
        {
            _context = context;
        }
        [HttpPost]
        public EventModel AddEvent([FromBody] EventModel eventModel)
        {
            EventModel entity = _context.AddEvent(eventModel);
            
            return entity;
        }
        
        [HttpGet]
        [Route("{id}")]
        public EventModel GetEvent(int id)
        {
            return _context.FindEvent(id);
        }
        [HttpPut]
        public ActionResult<EventModel> EditEvent( [FromBody] EventModel eventModel)
        {
            _context.UpdateEvent(eventModel);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public ActionResult<EventModel> DeleteEvent(int id)
        {
            _context.DeleteEvent(id);
            return _context.FindEvent(id);
        }

        [HttpGet]
        public IList<EventModel> GetEvents()
        {
            return _context.FindAllEvents();
        }
        
    }
}
