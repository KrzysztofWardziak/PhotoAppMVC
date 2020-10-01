using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PhotoAppMVC.Web.Controllers
{
    public class CustomerController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            // utworzyc widok dla tej akcji 
            // tabela z klientami
            // filtrowanie klientów
            // przygotowac dane - utworzyc w db
            // przekazac filtry do serwius
            // serwis musi przygotowac
            // serwis musi zwrocic dane w odpowiednim formacie

            var model = customerService.GetAllCustomersForList();
            return View();
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            // formularz z pustymi polami do wypelnienia dla klienta
            return View();
        }
        [HttpPost]
        public IActionResult AddCustomer(CustomerModel model)
        {
            var id = customerService.AddCustomer(model);
            return View();
        }

        [HttpGet]
        public IActionResult AddNewAddressForClient(int customerId)
        {
            return View(); 
        }

        [HttpPost] 
        public IActionResult AddNewAddressForClient(AddressModel model)
        {
            return View();
        }

        public IActionResult ViewCustomer(int customerId)
        {
            var customerModel = customerService.GetCustomerDetails(customerId);
            return View(customerModel);
        }  
    }
}
