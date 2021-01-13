using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Http;
using PhotoAppMVC.Domain.Model;
using PhotoAppMVC.Application.Mapping;
using System.Web;

namespace PhotoAppMVC.Application.ViewModels
{
    public class NewBlogVM : IMapFrom<BlogDetails>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string PhotoPath { get; set; }
        public string CreatedDate { get; set; }
        public string? ModifiedDate { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewBlogVM, BlogDetails>().ReverseMap();

        }

    }

}
