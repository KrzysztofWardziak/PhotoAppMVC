using AutoMapper;
using AutoMapper.QueryableExtensions;
using PhotoAppMVC.Application.Interfaces;
using PhotoAppMVC.Application.ViewModels.Customer;
using PhotoAppMVC.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoAppMVC.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;
        public int AddCustomer(NewCustomerVM customerId)
        {
            throw new NotImplementedException();
        }

        public ListCustomerForListVM GetAllCustomersForList()
        {
            var customers = _customerRepo.GetAllActiveCustomers().
                ProjectTo<CustomerForListVM>(_mapper.ConfigurationProvider).ToList();

            var customerList = new ListCustomerForListVM()
            {
                Customers = customers,
                Count = customers.Count
            };
            return customerList;


        }

        public CustomerDetailsVM GetCustomerDetails(int customerId)
        {
            var customer = _customerRepo.GetCustomer(customerId);
            var customerVM = _mapper.Map<CustomerDetailsVM>(customer);

            customerVM.Addresses = new List<AddressForListVM>();
            customerVM.PhoneNumber = new List<ContactDetailListVM>();
            customerVM.Emails = new List<ContactDetailListVM>();

            foreach(var address in customer.Addresses)
            {
                var add = new AddressForListVM()
                {
                    Id = address.Id,
                    Country = address.Country,
                    City = address.City
                };
                customerVM.Addresses.Add(add);
                
            }
            return customerVM;
        }
    }
}
