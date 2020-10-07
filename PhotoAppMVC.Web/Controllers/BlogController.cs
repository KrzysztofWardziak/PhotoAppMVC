using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoAppMVC.Application.Interfaces;
using PhotoAppMVC.Application.ViewModels;
using PhotoAppMVC.Domain.Interface;

namespace PhotoAppMVC.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _blogService.GetBlogForView(8, 1, "");
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }

            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _blogService.GetBlogForView(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            return View(new NewBlogVM());

        }
        [HttpPost]
        public IActionResult AddBlog(NewBlogVM blog)
        {
            var id = _blogService.AddNewBlog(blog);
            return RedirectToAction("Index");

        }

    }
}
