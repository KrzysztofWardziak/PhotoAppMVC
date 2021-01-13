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
            var date = DateTime.Now.ToString("F");
            contactMessage.Date = date;
            _context.ContactMessages.Add(contactMessage);
            _context.SaveChanges();
            return contactMessage.Id;
        }

        public void DeleteMessage(int id)
        {
            var cont = _context.ContactMessages.Find(id);
            if (cont != null)
            {
                _context.ContactMessages.Remove(cont);
                _context.SaveChanges();
            }
        }

        public IQueryable<ContactMessage> GetAllMessage()
        {
            return _context.ContactMessages;
        }

        public ContactMessage GetMessage(int contactId)
        {
            return _context.ContactMessages.FirstOrDefault(c => c.Id == contactId);
        }
    }
}
