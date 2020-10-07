using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AutoMapper;
using FluentValidation;
using PhotoAppMVC.Application.Mapping;
using PhotoAppMVC.Application.ViewModels.Customer;
using PhotoAppMVC.Domain.Model;

namespace PhotoAppMVC.Application.ViewModels.Contact
{
    public class NewContactMessageVM : IMapFrom<ContactMessage>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewContactMessageVM, ContactMessage>().ReverseMap();

        }
    }
    public class NewMessageValidation : AbstractValidator<NewContactMessageVM>
    {
        public NewMessageValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).MinimumLength(5);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Message).MaximumLength(550);
        }
    }
}
