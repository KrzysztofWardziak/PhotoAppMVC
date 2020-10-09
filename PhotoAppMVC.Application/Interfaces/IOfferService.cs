using PhotoAppMVC.Application.ViewModels.Offer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAppMVC.Application.Interfaces
{
    public interface IOfferService
    {
        int AddNewOffer(NewOfferVM offer);
        OfferViewVM GetOfferForView(int pageSize, int pageNo, string searchString);
        NewOfferVM GetOfferForEdit(int id);
        void UpdateOffer(NewOfferVM model);
        void DeleteOffer(int id);


    }
}
