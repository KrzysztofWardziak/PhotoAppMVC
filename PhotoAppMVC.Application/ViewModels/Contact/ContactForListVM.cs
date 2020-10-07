using System;
using AutoMapper;
using FluentValidation;
using PhotoAppMVC.Application.Mapping;
using PhotoAppMVC.Application.ViewModels.Customer;
using PhotoAppMVC.Domain.Model;

namespace PhotoAppMVC.Application.ViewModels.Contact
{
    public class ContactForListVM : IMapFrom<ContactMessage>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<ContactMessage, ContactForListVM>();

        }
    }
}