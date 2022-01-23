using ASP_Event_Project.Migrations.AppIdentityDb;
using ASP_Event_Project.Models;
using ASP_Event_Project.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Controllers
{
    public class EventController : Controller
    {
        private ICrudEventRepository _repository;
        

        public EventController(ICrudEventRepository repository)
        {
            _repository = repository;
            
        }
        public IActionResult Index()
        {
            return View(_repository.FindAllEvents());
        }
        
        public IActionResult AddEvent()
        {
            
            return View();
        }
        public IActionResult Details(int id)
        {
            return View(_repository.FindEvent(id));
        }
       [HttpPost]
       public IActionResult Add(EventModel eventModel)
        {
            if (ModelState.IsValid)
            {
                return View("ConfirmEvent", _repository.AddEvent(eventModel));
            }
            else
                return View("AddEvent");
        }


        public IActionResult EditEvent(int id)
        {
            return View(_repository.FindEvent(id));
        }
        [HttpPost]
        public IActionResult Edit(EventModel eventModel)
        {
            _repository.UpdateEvent(eventModel);
            return View("Index", _repository.FindAllEvents());
        }
        public IActionResult DeleteEvent(int id)
        {
            var match = _repository.FindEvent(id);
            if (match == null)
            {
                return NotFound();
            }
            else
            {
                _repository.DeleteEvent(id);
                return RedirectToAction("Index");
            }

        }
        

    }
}
