using PhotoAppMVC.Domain.Interface;
using PhotoAppMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoAppMVC.Infrastructure.Repositores
{
    public class OfferRepository : IOfferRepository
    {
        private readonly Context _context;

        public OfferRepository(Context context)
        {
            _context = context;
        }
        public int AddOffer(Offer offer)
        {
            var date = DateTime.Now.ToString("F");
            offer.Date = date;
            _context.Offers.Add(offer);           
            _context.SaveChanges();
            return offer.Id;
        }

        public void DeleteOffer(int id)
        {
            var offer = _context.Offers.Find(id);
            if (offer != null)
            {
                _context.Offers.Remove(offer);
                _context.SaveChanges();
            }

        }

        public IQueryable<Offer> GetAllOffers()
        {
            return _context.Offers;
        }

        public Offer GetOffer(int offerId)
        {
            return _context.Offers.FirstOrDefault(x => x.Id == offerId);

        }

        public void UpdateOffer(Offer offer)
        {
            _context.Attach(offer);
            _context.Entry(offer).Property("Name").IsModified = true;
            _context.Entry(offer).Property("Text").IsModified = true;
            _context.Entry(offer).Property("Price").IsModified = true;
            _context.SaveChanges();
        }
    }
}
