using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using PhotoAppMVC.Application.Interfaces;
using PhotoAppMVC.Application.ViewModels.Contact;
using PhotoAppMVC.Application.ViewModels.Customer;
using PhotoAppMVC.Domain.Interface;
using PhotoAppMVC.Domain.Model;

namespace PhotoAppMVC.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly  IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        
        public int AddMessage(NewContactMessageVM contactId)
        {
            var contact = _mapper.Map<ContactMessage>(contactId);
            var id = _contactRepository.AddMessage(contact);
            return id;
        }

        public ListContactMessageVM GetAllContactsForList(int pageSize, int pageNo, string searchString)
        {
            var contacts = _contactRepository.GetAllMessage().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<ContactForListVM>(_mapper.ConfigurationProvider).ToList();

           
            
            var contactToShow = contacts.Skip(pageSize * (pageNo - 1)).Take(pageSize).ToList();
            var contactList = new ListContactMessageVM()
            {
                
                PageSize = pageSize,
                CurrentPage = pageNo,
                SearchString = searchString,
                Contacts = contactToShow,
                Count = contacts.Count,
                
            };
            
            return contactList;
        }
    }
}
