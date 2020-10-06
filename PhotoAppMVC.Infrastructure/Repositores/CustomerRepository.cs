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
        private readonly Context _context;

        public CustomerRepository(Context context)
        {
            _context = context;
        }
        public IQueryable<Customer> GetAllActiveCustomers()
        {
            return _context.Customers.Where(p => p.isActive);
        }

        public Customer GetCustomer(int customerId)
        {
                return _context.Customers.FirstOrDefault(p => p.Id == customerId);

        }

        public int AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            customer.isActive = true;
            _context.SaveChanges();
            return customer.Id;
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Attach(customer);
            _context.Entry(customer).Property("Name").IsModified = true;
            _context.Entry(customer).Property("NIP").IsModified = true;
            _context.Entry(customer).Property("Regon").IsModified = true;
            _context.SaveChanges();
        }

        public void DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if(customer != null)
            {
                 _context.Customers.Remove(customer);
                 _context.SaveChanges();
            }
        }
    }
}
