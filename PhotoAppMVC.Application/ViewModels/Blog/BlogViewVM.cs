using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PhotoAppMVC.Domain.Model;

namespace PhotoAppMVC.Application.ViewModels.Blog
{
    public class BlogViewVM
    {
        public List<BlogForListVM> Blogs { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }

 
    }
}
