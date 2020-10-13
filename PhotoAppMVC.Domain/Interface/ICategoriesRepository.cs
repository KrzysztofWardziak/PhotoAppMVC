using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoAppMVC.Domain.Model;

namespace PhotoAppMVC.Domain.Interface
{
    public interface ICategoriesRepository
    {
        IQueryable<Categories> GetAllCategories();
        Categories GetCategories(int categoriesId);

        int AddCategory(Categories categories);
        void UpdateCategory(Categories category);
        void DeleteCategory(int id);
    }
}
