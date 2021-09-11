using DataAccess.Design_Pattern.Repositories.Interfaces;
using DataContext.Context;
using Models.Entities.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Design_Pattern.Repositories.Classes
{
    public class ContactUsRepository : GenericRepository.GenericRepsotory<ContactUs>, IContactUsRepository
    {
        private readonly ParsaPanahpoorDbContext _db;

        public ContactUsRepository(ParsaPanahpoorDbContext db) : base(db)
        {
            _db = db;
        }

        public void AddContactUsMessage(ContactUs contact)
        {
            ContactUs contact1 = new ContactUs()
            {
                UserName = contact.UserName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                MessageContent = contact.MessageContent,
                CreateDate = DateTime.Now
            };

            Add(contact);
        }

        public List<ContactUs> GetAllMessages()
        {
            return GetAll().ToList();
        }

        public ContactUs GetContactUsById(int id)
        {
            return GetFirstOrDefault(p => p.ID == id);
        }
    }
}
