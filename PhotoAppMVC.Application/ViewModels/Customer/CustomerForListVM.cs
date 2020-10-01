using AutoMapper;
using PhotoAppMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAppMVC.Application.ViewModels.Customer
{
    public class CustomerForListVM : IMapFrom<PhotoAppMVC.Domain.Model.Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PhotoAppMVC.Domain.Model.Customer, CustomerForListVM>();

        }

    }
}
