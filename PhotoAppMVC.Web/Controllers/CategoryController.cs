﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoAppMVC.Application.Interfaces;
using PhotoAppMVC.Application.ViewModels;
using PhotoAppMVC.Application.ViewModels.Categories;
using PhotoAppMVC.Domain.Model;

namespace PhotoAppMVC.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoriesService _categoriesService;

        public CategoryController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _categoriesService.GetCategoryForView();
            return View(model);
        }

        //[HttpPost]
        //public IActionResult Index()
        //{
        //    var model = _categoriesService.GetCategoryForView();
        //    return View(model);
        //}
        [HttpGet]
        public IActionResult AddCategory()
        {
            return View(new NewCategoriesVM());

        }
        [HttpPost]
        public IActionResult AddCategory(NewCategoriesVM categories)
        {

            var id = _categoriesService.AddNewCategories(categories);
            return RedirectToAction("Index");

        }

    }
}
