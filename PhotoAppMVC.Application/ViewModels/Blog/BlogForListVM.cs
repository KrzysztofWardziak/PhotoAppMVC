using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PhotoAppMVC.Domain.Model;
using PhotoAppMVC.Application.Mapping;


namespace PhotoAppMVC.Application.ViewModels.Blog
{
    public class BlogForListVM : IMapFrom<BlogDetails>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string PhotoPath { get; set; }
        public string CreatedDate { get; set; }
        public string? ModifiedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<BlogDetails, BlogForListVM>();

        }
    }
}
