using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace PhotoAppMVC.Application.ViewModels.Contact
{
    public class ListContactMessageVM
    {
        public List<ContactForListVM> Contacts { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public int Count { get; set; }
        

    }
}
