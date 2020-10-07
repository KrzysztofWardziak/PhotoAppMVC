using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoAppMVC.Domain.Model;

namespace PhotoAppMVC.Domain.Interface
{
    public interface IBlogRepository
    {
        IQueryable<BlogDetails> GetAllBlogs();
        BlogDetails GetBlog(int blogId);

        int AddBlog(BlogDetails blog);
        void UpdateBlog(BlogDetails blog);
        void DeleteBlog(int id);
    }
}
