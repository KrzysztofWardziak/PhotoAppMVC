using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PhotoAppMVC.Application.Interfaces;
using PhotoAppMVC.Application.ViewModels;
using PhotoAppMVC.Application.ViewModels.Blog;
using PhotoAppMVC.Application.ViewModels.Categories;
using PhotoAppMVC.Domain.Interface;
using PhotoAppMVC.Domain.Model;

namespace PhotoAppMVC.Application.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;

        public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }

        public int AddNewCategories(NewCategoriesVM categories)
        {
            var cat = _mapper.Map<Categories>(categories);
            var id = _categoriesRepository.AddCategory(cat);
            return id;
        }

        public void DeleteCategory(int id)
        {
            _categoriesRepository.DeleteCategory(id);
        }

        public NewCategoriesVM GetCategoryForEdit(int id)
        {
            var cat = _categoriesRepository.GetCategories(id);
            var catVM = _mapper.Map<NewCategoriesVM>(cat);
            return catVM;
        }

        public CategoriesViewVM GetCategoryForView()
        {
            var categories = _categoriesRepository.GetAllCategories().ProjectTo<CategoriesForListVM>(_mapper.ConfigurationProvider).ToList();

            var categoryList = new CategoriesViewVM()
            {
                Categorieses = categories

            };

            return categoryList;
        }

        public void UpdateCategory(NewCategoriesVM model)
        {
            var cate = _mapper.Map<Categories>(model);
            _categoriesRepository.UpdateCategory(cate);
        }
    }
}
