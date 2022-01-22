using ASP_Event_Project.Models;
using ASP_Event_Project.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Mock
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category {CategoryName = "Sport", Description="Wszystkie sportowe wydarzenia"},
                    new Category {CategoryName="Wypoczynek", Description="Wszystkie wydarzenia związane z wypoczynkiem"}
                };
            }
        }
    }
}
