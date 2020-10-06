using PhotoAppMVC.Application.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAppMVC.Application.Interfaces
{
    public interface ICustomerService
    {
        ListCustomerForListVM GetAllCustomersForList(int pageSize, int pageNo, string searchString);
        int AddCustomer(NewCustomerVM customerId);
        CustomerDetailsVM GetCustomerDetails(int idd);
        NewCustomerVM GetCustomerForEdit(int id);
        void UpdateCustomer(NewCustomerVM model);
        void DeleteCustomer(int id);
    }
}
