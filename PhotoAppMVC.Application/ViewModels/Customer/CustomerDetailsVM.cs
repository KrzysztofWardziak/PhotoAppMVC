using AutoMapper;
using PhotoAppMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAppMVC.Application.ViewModels.Customer
{
    public class CustomerDetailsVM : IMapFrom<PhotoAppMVC.Domain.Model.Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
        public string CEOFullName { get; set; }
        public string FirstLineOfContactInformation { get; set; }
        public List<AddressForListVM> Addresses { get; set; }
        public List<ContactDetailListVM> Emails { get; set; }
        public List<ContactDetailListVM> PhoneNumber { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<PhotoAppMVC.Domain.Model.Customer, CustomerDetailsVM>()
               .ForMember(s => s.CEOFullName, opt => opt.MapFrom(d => d.CEOName + " " + d.CEOLastName))
               .ForMember(s => s.FirstLineOfContactInformation, 
               opt => opt.MapFrom(d => d.CustomerContactInformation.FirstName + " " + d.CustomerContactInformation.LastName))
               .ForMember(s => s.Addresses, opt => opt.Ignore())
               .ForMember(s => s.Emails, opt=> opt.Ignore())
               .ForMember(s => s.PhoneNumber, opt => opt.Ignore());

        }
    }
}
