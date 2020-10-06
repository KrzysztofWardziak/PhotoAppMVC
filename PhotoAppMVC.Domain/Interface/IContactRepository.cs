using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoAppMVC.Domain.Model;

namespace PhotoAppMVC.Domain.Interface
{
    public interface IContactRepository
    {
        int AddMessage(ContactMessage contactMessage);
        IQueryable<ContactMessage> GetAllMessage();
    }
}
