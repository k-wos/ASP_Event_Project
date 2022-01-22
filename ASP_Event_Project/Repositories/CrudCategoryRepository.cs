using ASP_Event_Project.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Event_Project.Repositories
{
    public class CrudCategoryRepository : ICrudCategoryRepository
    {
        private ApplicationDbContext _context;

        public CrudCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Category FindCategory(int id)
        {
            return _context.Categories.Find(id);
        }

        public Category AddCategory(Category category)
        {
            var entity = _context.Categories.Add(category).Entity;
            _context.SaveChanges();
            return entity;
        }

        public Category UpdateCategory(Category category)
        {
            Category original = _context.Categories.Find(category.CategoryId);
            original.CategoryName = category.CategoryName;
            original.Description = category.Description;
            EntityEntry<Category> entityEntry = _context.Categories.Update(original);
            _context.SaveChanges();
            return entityEntry.Entity;
        }
        public Category DeleteCategory(int id)
        {
            Category category = _context.Categories.Remove(FindCategory(id)).Entity;
            _context.SaveChanges();
            return category;
        }

        public IList<Category> FindAllCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
