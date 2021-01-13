using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoAppMVC.Application.Interfaces;
using PhotoAppMVC.Application.ViewModels;
using PhotoAppMVC.Application.ViewModels.Blog;
using PhotoAppMVC.Domain.Interface;
using PhotoAppMVC.Domain.Model;
using PhotoAppMVC.Infrastructure;
using Serilog;

namespace PhotoAppMVC.Web.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Context _context;

        public BlogController(IBlogService blogService, IWebHostEnvironment webHostEnvironment, Context context)
        {
            _blogService = blogService;
            _webHostEnvironment = webHostEnvironment;
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _blogService.GetBlogForView();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddBlog()
        {
            return View(new NewBlogVM());

        }
        [HttpPost]
        public IActionResult AddBlog(NewBlogVM blog, IFormFile file)
        {
            blog.PhotoPath = file.FileName;
            var id = _blogService.AddNewBlog(blog);
                return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var blog = _blogService.GetBlogForEdit(id);
            return View(blog);
        }
        [HttpPost]
        public IActionResult EditBlog(NewBlogVM model)
        {
            if (ModelState.IsValid)
            {
                _blogService.UpdateBlog(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            _blogService.DeleteBlog(id);
            return RedirectToAction("Index");
        }

    }
}
