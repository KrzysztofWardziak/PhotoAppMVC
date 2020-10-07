using PhotoAppMVC.Domain.Interface;
using PhotoAppMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoAppMVC.Infrastructure.Repositores
{
    public class BlogRepository : IBlogRepository
    {

        private readonly Context _context;

        public BlogRepository(Context context)
        {
            _context = context;
        }
        public int AddBlog(BlogDetails blog)
        {
            var date = DateTime.Now.ToString("F");
            blog.CreatedDate = date;
            _context.Blogs.Add(blog);
            _context.SaveChanges();
            return blog.Id;
        }

        public void DeleteBlog(int id)
        {
            var blog = _context.Blogs.Find(id);
            if (blog != null)
            {
                _context.Blogs.Remove(blog);
                _context.SaveChanges();
            }
        }

        public IQueryable<BlogDetails> GetAllBlogs()
        {
            return _context.Blogs;
        }

        public BlogDetails GetBlog(int blogId)
        {
            return _context.Blogs.FirstOrDefault(x => x.Id == blogId);
        }

        public void UpdateBlog(BlogDetails blog)
        {
            _context.Attach(blog);
            _context.Entry(blog).Property("Title").IsModified = true;
            _context.Entry(blog).Property("Text").IsModified = true;
            _context.Entry(blog).Property("PhotoPath").IsModified = true;
            _context.SaveChanges();
        }
    }
}
