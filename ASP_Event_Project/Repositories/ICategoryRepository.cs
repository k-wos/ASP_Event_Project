using ASP_Event_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Repositories
{
    interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
