using System;
using System.Collections.Generic;
using System.Text;
using PhotoAppMVC.Application.ViewModels.Contact;

namespace PhotoAppMVC.Application.Interfaces
{
    public interface IContactService
    {
        ListContactMessageVM GetAllContactsForList(int pageSize, int pageNo, string searchString);

        int AddMessage(NewContactMessageVM contactId);
    }
}
