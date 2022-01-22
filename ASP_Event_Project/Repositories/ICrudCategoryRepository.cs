using ASP_Event_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Repositories
{
    public interface ICrudCategoryRepository
    {
        Category FindCategory(int id);
        Category DeleteCategory(int id);
        Category AddCategory(Category category);
        Category UpdateCategory(Category category);

        IList<Category> FindAllCategories();
    }
}
