using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoAppMVC.Application.Interfaces;
using PhotoAppMVC.Application.ViewModels.Customer;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhotoAppMVC.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _custService;

        public CustomerController(ICustomerService custService)
        {
            _custService = custService;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            var model = _custService.GetAllCustomersForList(8, 1, "");
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
            var model = _custService.GetAllCustomersForList(pageSize, pageNo.Value, searchString);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            // formularz z pustymi polami do wypelnienia dla klienta
            return View(new NewCustomerVM());
        }
        [HttpPost]
        public IActionResult AddCustomer(NewCustomerVM model)
        {
            
            var id = _custService.AddCustomer(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditCustomer(int id)
        {
            var customer = _custService.GetCustomerForEdit(id);
            return View(customer);
        }
        [HttpPost]
        public IActionResult EditCustomer(NewCustomerVM model)
        {
            if (ModelState.IsValid)
            {
                _custService.UpdateCustomer(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        //[HttpGet]
        //public IActionResult AddNewAddressForClient(int customerId)
        //{
        //    return View(); 
        //}

        //[HttpPost] 
        //public IActionResult AddNewAddressForClient(AddressModel model)
        //{
        //    return View();
        //}

        public IActionResult ViewCustomer(int id)
        {
            var customerModel = _custService.GetCustomerDetails(id);
            return View(customerModel);
        }

        public IActionResult Delete(int id)
        {
            _custService.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
