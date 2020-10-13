using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PhotoAppMVC.Application.Mapping;
using PhotoAppMVC.Domain.Model;


namespace PhotoAppMVC.Application.ViewModels
{
    public class CategoriesForListVM : IMapFrom<Domain.Model.Categories>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int Sorting { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Model.Categories, CategoriesForListVM>();

        }
    }
}
