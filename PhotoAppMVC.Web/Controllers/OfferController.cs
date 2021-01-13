using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoAppMVC.Application.Interfaces;
using PhotoAppMVC.Application.ViewModels.Offer;

namespace PhotoAppMVC.Web.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _offerService.GetOfferForView(8, 1, "");
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(int pageSize, int? pageNo, string searchString)
        {
            if (!pageNo.HasValue)
            {
                pageNo = 1;
            }

            if (searchString is null)
            {
                searchString = String.Empty;
            }
            var model = _offerService.GetOfferForView(pageSize, pageNo.Value, searchString);
            return View(model);
        }


        [HttpGet]
        public IActionResult AddOffer()
        {

            return View(new NewOfferVM());


        }
        [HttpPost]
        public IActionResult AddOffer(NewOfferVM offer)
        {

            var id = _offerService.AddNewOffer(offer);

            return RedirectToAction("Index");


        }

        [HttpGet]
        public IActionResult EditOffer(int id)
        {
            var offer = _offerService.GetOfferForEdit(id);
            return View(offer);
        }

        [HttpPost]
        public IActionResult EditOffer(NewOfferVM model)
        {
            if (ModelState.IsValid)
            {
                _offerService.UpdateOffer(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult DeleteOffer(int id)
        {
            _offerService.DeleteOffer(id);
            return RedirectToAction("Index");

        }
    }
}