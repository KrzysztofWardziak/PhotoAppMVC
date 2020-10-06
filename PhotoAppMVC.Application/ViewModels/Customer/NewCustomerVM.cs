using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;
using AutoMapper;
using FluentValidation;
using PhotoAppMVC.Application.Mapping;

namespace PhotoAppMVC.Application.ViewModels.Customer
{
    public class NewCustomerVM : IMapFrom<Domain.Model.Customer>
    {
        
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
        public bool isActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewCustomerVM, PhotoAppMVC.Domain.Model.Customer>().ReverseMap();

        }
    }

    public class NewCustomerValidation : AbstractValidator<NewCustomerVM>
    {
        public NewCustomerValidation()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.NIP).Length(10);
            RuleFor(x => x.REGON).Length(9, 14);
            RuleFor(x => x.Name).MaximumLength(255);
        }
    }
}
