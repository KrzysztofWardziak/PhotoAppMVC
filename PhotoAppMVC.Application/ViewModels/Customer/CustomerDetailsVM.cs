using System;
using System.Collections.Generic;
using System.Text;

namespace PhotoAppMVC.Application.ViewModels.Customer
{
    public class CustomerDetailsVM
    {
        public int Id { get; set; }
        public string NIP { get; set; }
        public string REGON { get; set; }
        public string CEOFullName { get; set; }
        public string FirstLineOfContactInformation { get; set; }
        public List<AddressForListVM> Addresses { get; set; }
        public List<ContactDetailListVM> Emails { get; set; }
        public List<ContactDetailListVM> PhoneNumber { get; set; }

    }
}
