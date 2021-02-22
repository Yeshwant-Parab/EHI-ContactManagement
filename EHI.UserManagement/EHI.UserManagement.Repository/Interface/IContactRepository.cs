using EHI.UserManagement.Dto.Contact;
using System.Collections.Generic;

namespace EHI.UserManagement.Repository.Interface
{
    /// <summary>
/// Interface to expose ContactRepository functionalities
/// </summary>
    public interface IContactRepository
    {
        IEnumerable<ContactDetails> Get();
        ContactDetails Get(int id);
        bool Create(ContactDetails contact);
        bool Update(ContactDetails contact);
    }
}
