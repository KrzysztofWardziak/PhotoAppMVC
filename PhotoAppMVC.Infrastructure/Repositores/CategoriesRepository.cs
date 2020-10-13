using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoAppMVC.Domain.Interface;
using PhotoAppMVC.Domain.Model;

namespace PhotoAppMVC.Infrastructure.Repositores
{


    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly Context _context;

        public CategoriesRepository(Context context)
        {
            _context = context;
        }
        public int AddCategory(Categories categories)
        {
            _context.Categorieses.Add(categories);
            _context.SaveChanges();
            return categories.Id;

        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categorieses.Find(id);
            if (category != null)
            {
                _context.Categorieses.Remove(category);
                _context.SaveChanges();
            }
        }

        public IQueryable<Categories> GetAllCategories()
        {
            return _context.Categorieses;
        }

        public Categories GetCategories(int categoriesId)
        {
            return _context.Categorieses.FirstOrDefault(x => x.Id == categoriesId);
        }

        public void UpdateCategory(Categories category)
        {
            _context.Attach(category);
            _context.Entry(category).Property("Name").IsModified = true;
            _context.Entry(category).Property("Slug").IsModified = true;
            _context.Entry(category).Property("Sorting").IsModified = true;
            _context.SaveChanges();
        }
    }
}
