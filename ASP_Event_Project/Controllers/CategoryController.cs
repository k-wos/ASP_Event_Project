using ASP_Event_Project.Models;
using ASP_Event_Project.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICrudCategoryRepository _repository;

        public CategoryController(ICrudCategoryRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View(_repository.FindAllCategories());
        }
        public IActionResult EditCategory(int id)
        {
            return View(_repository.FindCategory(id));
        }
        public IActionResult Edit(Category category)
        {
            _repository.UpdateCategory(category);
            return View("Index", _repository.FindAllCategories());
        }
        public IActionResult DeleteCategory(int id)
        {
            return View(_repository.FindCategory(id));
        }
        public IActionResult Delete(int id)
        {
            _repository.DeleteCategory(id);
            return View("Index", _repository.FindAllCategories());
        }

    }
}
