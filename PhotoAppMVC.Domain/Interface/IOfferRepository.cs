using PhotoAppMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoAppMVC.Domain.Interface
{
    public interface IOfferRepository
    {
        IQueryable<Offer> GetAllOffers();
        Offer GetOffer(int offerId);

        int AddOffer(Offer offer);
        void UpdateOffer(Offer offer);
        void DeleteOffer(int id);
    }
}
