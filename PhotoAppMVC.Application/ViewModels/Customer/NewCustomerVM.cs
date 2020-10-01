using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAppMVC.Application.ViewModels.Customer
{
    public class NewCustomerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
    }
}
