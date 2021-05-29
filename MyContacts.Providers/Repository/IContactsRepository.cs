using MyContacts.Entities;
using System.Collections.Generic;

namespace MyContacts.Providers.Repository
{
    public interface IContactsRepository
    {
        void Add(Contacts item);
        IEnumerable<Contacts> GetAll();
        Contacts Find(int id);
        void Remove(int Id);
        void Update(Contacts item);
    }
}
