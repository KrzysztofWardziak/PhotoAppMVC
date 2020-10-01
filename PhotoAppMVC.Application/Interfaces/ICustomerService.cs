using PhotoAppMVC.Application.ViewModels.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAppMVC.Application.Interfaces
{
    public interface ICustomerService
    {
        ListCustomerForListVM GetAllCustomersForList();
        int AddCustomer(NewCustomerVM customerId);
        CustomerDetailsVM GetCustomerDetails(int customerId);
    }
}
