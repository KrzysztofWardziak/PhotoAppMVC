using System;
using System.Collections.Generic;
using System.Text;
using PhotoAppMVC.Application.ViewModels;
using PhotoAppMVC.Application.ViewModels.Categories;

namespace PhotoAppMVC.Application.Interfaces
{
    public interface ICategoriesService
    {
        int AddNewCategories(NewCategoriesVM categories);
        
        CategoriesViewVM GetCategoryForView();
        NewCategoriesVM GetCategoryForEdit(int id);
        void UpdateCategory(NewCategoriesVM model);
        void DeleteCategory(int id);
    }
}
