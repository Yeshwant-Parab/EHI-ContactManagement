using AutoMapper;
using EHI.UserManagement.Dto.Contact;
using EHI.UserManagement.Repository.Context;
using EHI.UserManagement.Repository.Entities;
using EHI.UserManagement.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EHI.UserManagement.Repository.Repositories
{
    /// <summary>
    /// Implementation of IContactRepository
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        private DatabaseContext _context;
        private readonly IMapper _iMapper;

        public ContactRepository(DatabaseContext context, IMapper iMapper)
        {
            _context = context;
            _iMapper = iMapper;
        }
        public bool Create(ContactDetails contact)
        {
            try
            {
                var newContact = _iMapper.Map<Contact>(contact);
                newContact.Status = Enums.ContactStatus.Active;
                _context.Contact.Add(newContact);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<ContactDetails> Get()
        {
            try
            {
                var contacts = _context.Contact.AsNoTracking().AsQueryable().Where(x=>x.Status == Enums.ContactStatus.Active);
                return _iMapper.Map<List<ContactDetails>>(contacts);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public ContactDetails Get(int id)
        {
            try
            {
                var contact = _context.Contact.AsNoTracking().FirstOrDefault(x => x.Id == id);
                return _iMapper.Map<ContactDetails>(contact);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Update(ContactDetails contact)
        {
            try
            {
                var existingContact = _iMapper.Map<Contact>(contact);
                _context.Contact.Update(existingContact);
                return _context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
