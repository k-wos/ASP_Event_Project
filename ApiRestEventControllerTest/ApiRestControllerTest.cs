using ASP_Event_Project.Repositories;
using System;
using Xunit;
using ASP_Event_Project.Models;
using ASP_Event_Project.Controllers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Event_Procject
{
    public class ApiRestControllerTest
    {
        [Fact]
        public void GetEventsTest()
        {
            EventMemoryRepository repository = new EventMemoryRepository();
            repository.AddEvent(new EventModel() { Name = "TEST" });
            repository.AddEvent(new EventModel() { Name = "TEST" });
            RestEventController controllerTest = new RestEventController(repository);
            IList<EventModel> events = controllerTest.GetEvents();
            Assert.Equal(2, events.Count);
        }
        [Fact]
        public void AddEventTest()
        {
            EventMemoryRepository repository = new EventMemoryRepository();
            repository.AddEvent(new EventModel() {  Name = "TEST" });
            repository.AddEvent(new EventModel() {  Name = "TEST" });
            RestEventController controllerTest = new RestEventController(repository);
            EventModel newEvent = new EventModel() { EventId = 50, Name = "NEW" };
            ActionResult<EventModel> actionResult = controllerTest.AddEvent(newEvent);
            Assert.Equal("NEW", repository.FindEvent(3).Name);
        }
        [Fact]
        public void FindEventId()
        {
            EventMemoryRepository repository = new EventMemoryRepository();
            repository.AddEvent(new EventModel() { EventId = 40, Name = "TEST" }) ;
            repository.AddEvent(new EventModel() { Name = "TEST" });
            RestEventController controllerTest = new RestEventController(repository);
            var test = repository.FindEvent(1);
            Assert.Equal("TEST", test.Name);

            


        }
    }
}
