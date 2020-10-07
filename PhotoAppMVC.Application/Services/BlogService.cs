using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PhotoAppMVC.Application.Interfaces;
using PhotoAppMVC.Application.ViewModels;
using PhotoAppMVC.Application.ViewModels.Blog;
using PhotoAppMVC.Application.ViewModels.Customer;
using PhotoAppMVC.Domain.Interface;
using PhotoAppMVC.Domain.Model;

namespace PhotoAppMVC.Application.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public BlogService(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }

        public int AddNewBlog(NewBlogVM blog)
        {
            var bl = _mapper.Map<BlogDetails>(blog);
            var id = _blogRepository.AddBlog(bl);
            return id;
        }

        public void DeleteBlog(int id)
        {
           _blogRepository.DeleteBlog(id);
        }

        public NewBlogVM GetBlogForEdit(int id)
        {
            var blog = _blogRepository.GetBlog(id);
            var blogVM = _mapper.Map<NewBlogVM>(blog);
            return blogVM;
        }

        public BlogViewVM GetBlogForView(int pageSize, int pageNo, string searchString)
        {
            var blogs = _blogRepository.GetAllBlogs().Where(p => p.Title.StartsWith(searchString) && p.Text.StartsWith(searchString))
                .ProjectTo<BlogForListVM>(_mapper.ConfigurationProvider).ToList();

            var blogsToShow = blogs.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var blogList = new BlogViewVM()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Blogs = blogsToShow,
                Count = blogs.Count

            };
            return blogList;
        }

        public void UpdateBlog(NewBlogVM model)
        {
            var blog = _mapper.Map<BlogDetails>(model);
            _blogRepository.UpdateBlog(blog);
        }
    }
}
