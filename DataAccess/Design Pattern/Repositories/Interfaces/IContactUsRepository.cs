using DataAccess.Design_Pattern.GenericRepository;
using Models.Entities.ContactUs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Design_Pattern.Repositories.Interfaces
{
    public interface IContactUsRepository : IGenericRepository<ContactUs>
    {
        void AddContactUsMessage(ContactUs contactUs);
        List<ContactUs> GetAllMessages();
        ContactUs GetContactUsById(int id);
    }
}
