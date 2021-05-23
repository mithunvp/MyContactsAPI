using MyContacts.Entities;
using System.Collections.Generic;

namespace MyContacts.Providers.Repository
{
    public interface IContactsRepository
    {
        Contacts Add(Contacts item);
        IEnumerable<Contacts> GetAll();
        Contacts Find(int id);
        void Remove(int Id);
        Contacts Update(Contacts item);
    }
}
