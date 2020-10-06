using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhotoAppMVC.Domain.Interface;
using PhotoAppMVC.Domain.Model;

namespace PhotoAppMVC.Infrastructure.Repositores
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }
        public int AddMessage(ContactMessage contactMessage)
        {

            _context.ContactMessages.Add(contactMessage);
            _context.SaveChanges();
            return contactMessage.Id;
        }

        public IQueryable<ContactMessage> GetAllMessage()
        {
            return _context.ContactMessages;
        }
    }
}
