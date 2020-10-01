using PhotoAppMVC.Domain.Interface;
using PhotoAppMVC.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoAppMVC.Infrastructure.Repositores
{
    public class CustomerRepository : ICustomerRepository
    {
        public IQueryable<Customer> GetAllActiveCustomers()
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
