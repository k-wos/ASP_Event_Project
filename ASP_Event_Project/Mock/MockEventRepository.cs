using ASP_Event_Project.Models;
using ASP_Event_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Mock
{
    public class MockEventRepository : IEventRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<EventModel> Events
        {
            get
            {
                return new List<EventModel>
                {
                    new EventModel
                    {
                        Name ="Grill",
                        AgeRange = "19-25",
                        Place = "ul. xxxxx 1/21 xxxx",
                        Description = "Grill, śpiew i taniec",
                        Price = 0.00M,
                        EventDate = new DateTime(2022,9,12,18,45,00),
                        Expired = false,
                        Category = _categoryRepository.Categories.Last()
                    },
                    new EventModel
                    {
                        Name ="Piłka nożna",
                        AgeRange = "30-40",
                        Place = "Hala przy ul. xxxxx 2 xxxx",
                        Description = "Gierki na hali, mini turniej",
                        Price = 0.00M,
                        EventDate = new DateTime(2022,2,15,20,00,00),
                        Expired = false,
                        Category = _categoryRepository.Categories.First()
                    }
                };
            }
        }
        public IEnumerable<EventModel> ExpiredEvents { get;  }
        public EventModel GetEventById(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}
