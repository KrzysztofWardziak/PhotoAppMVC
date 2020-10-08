using AutoMapper;
using AutoMapper.QueryableExtensions;
using PhotoAppMVC.Application.Interfaces;
using PhotoAppMVC.Application.ViewModels.Offer;
using PhotoAppMVC.Domain.Interface;
using PhotoAppMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoAppMVC.Application.Services
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public OfferService(IOfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }
        public int AddNewOffer(NewOfferVM offer)
        {
            var of = _mapper.Map<Offer>(offer);
            var id = _offerRepository.AddOffer(of);
            return id;
        }

        public void DeleteOffer(int id)
        {
            _offerRepository.DeleteOffer(id);
        }

        public NewOfferVM GetOfferForEdit(int id)
        {

            var offer = _offerRepository.GetOffer(id);
            var offerVM = _mapper.Map<NewOfferVM>(offer);
            return offerVM;
        }

        public OfferViewVM GetOfferForView(int pageSize, int pageNo, string searchString)
        {
            var offers = _offerRepository.GetAllOffers().Where(p => p.Name.StartsWith(searchString) && p.Text.StartsWith(searchString))
            .ProjectTo<OfferForListVM>(_mapper.ConfigurationProvider).ToList();

            var offersToShow = offers.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var offerList = new OfferViewVM()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Offers = offersToShow,
                Count = offers.Count

            };
            return offerList;
        }

        public void UpdateOffer(NewOfferVM model)
        {
            var offer = _mapper.Map<Offer>(model);
            _offerRepository.UpdateOffer(offer);
        }
    }
}
