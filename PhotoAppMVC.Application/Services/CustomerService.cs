using AutoMapper;
using AutoMapper.QueryableExtensions;
using PhotoAppMVC.Application.Interfaces;
using PhotoAppMVC.Application.ViewModels.Customer;
using PhotoAppMVC.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoAppMVC.Domain.Model;

namespace PhotoAppMVC.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }
        public int AddCustomer(NewCustomerVM customer)
        {
            var cust = _mapper.Map<Customer>(customer);
            var id = _customerRepo.AddCustomer(cust);
            return id;
        }

        public void DeleteCustomer(int id)
        {
            _customerRepo.DeleteCustomer(id);
        }

        public ListCustomerForListVM GetAllCustomersForList(int pageSize, int pageNo, string searchString)
        {
            var customers = _customerRepo.GetAllActiveCustomers().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<CustomerForListVM>(_mapper.ConfigurationProvider).ToList();

            var customersToShow = customers.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var customerList = new ListCustomerForListVM()
            {
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Customers = customersToShow,
                Count = customers.Count
            };
            return customerList;


        }

        public CustomerDetailsVM GetCustomerDetails(int id)
        {
            var customer = _customerRepo.GetCustomer(id);
            var customerVM = _mapper.Map<CustomerDetailsVM>(customer);

            customerVM.Addresses = new List<AddressForListVM>();
            customerVM.PhoneNumber = new List<ContactDetailListVM>();
            customerVM.Emails = new List<ContactDetailListVM>();
             
            
            
            foreach (var address in customerVM.Addresses)
            {
                var add = new AddressForListVM()
                {
                    Id = address.Id,
                    Country = address.Country,
                    City = address.City,
                    BuildingNumber = address.BuildingNumber,
                    FlatNumber = address.FlatNumber,
                    Street = address.Street,
                    ZipCode = address.ZipCode,
                    CustomerId = address.CustomerId,
                    Customer = address.Customer,
                    
                };
                customerVM.Addresses.Add(add);
                
            }
            return customerVM;

        }

        public NewCustomerVM GetCustomerForEdit(int id)
        {
            var customer = _customerRepo.GetCustomer(id);
            var customerVM = _mapper.Map<NewCustomerVM>(customer);
            return customerVM;
        }

        public void UpdateCustomer(NewCustomerVM model)
        {
            var customer = _mapper.Map<Customer>(model);
            _customerRepo.UpdateCustomer(customer);
        }
    }
}
