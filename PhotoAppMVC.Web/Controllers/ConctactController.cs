using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoAppMVC.Application.Interfaces;
using PhotoAppMVC.Application.ViewModels.Contact;

namespace PhotoAppMVC.Web.Controllers
{
    public class ConctactController : Controller
    {
        private readonly IContactService _contService;

        public ConctactController(IContactService contService)
        {
            _contService = contService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _contService.GetAllContactsForList(10, 1, "");
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
            var model = _contService.GetAllContactsForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddNewMessage()
        {
            return View( new NewContactMessageVM());
        }
        [HttpPost]
        public IActionResult AddNewMessage(NewContactMessageVM contact)
        {
                var id = _contService.AddMessage(contact);
                return RedirectToAction("Index");

        }
        public IActionResult Contact_us()
        {
            return View();
        }


    }
}
