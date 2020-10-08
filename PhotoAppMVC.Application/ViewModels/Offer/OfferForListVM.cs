using AutoMapper;
using PhotoAppMVC.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Text;


namespace PhotoAppMVC.Application.ViewModels.Offer
{
    public class OfferForListVM : IMapFrom<PhotoAppMVC.Domain.Model.Offer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }
        public string Date { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PhotoAppMVC.Domain.Model.Offer, OfferForListVM>();

        }
    }
}
