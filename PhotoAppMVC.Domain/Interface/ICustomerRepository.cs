using PhotoAppMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoAppMVC.Domain.Interface
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetAllActiveCustomers();
        Customer GetCustomer(int customerId);
    }
}
