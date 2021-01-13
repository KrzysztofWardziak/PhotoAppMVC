using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PhotoAppMVC.Application.ViewModels;
using PhotoAppMVC.Application.ViewModels.Blog;

namespace PhotoAppMVC.Application.Interfaces
{
    public interface IBlogService
    {
        int AddNewBlog(NewBlogVM blog);
        //BlogViewVM GetBlogForView(int pageSize, int pageNo, string searchString);
        BlogViewVM GetBlogForView();
        NewBlogVM GetBlogForEdit(int id);
        void UpdateBlog(NewBlogVM model);
        void DeleteBlog(int id);

    }
}
