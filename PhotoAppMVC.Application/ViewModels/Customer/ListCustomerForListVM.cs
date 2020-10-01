using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAppMVC.Application.ViewModels.Customer
{
    public class ListCustomerForListVM
    {
        public List<CustomerForListVM> Customers { get; set; }
        public int Count { get; set; }

    }
}
