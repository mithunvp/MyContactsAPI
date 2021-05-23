using System.Collections.Generic;
using System.Linq;
using MyContacts.Entities;
using MyContacts.Providers.DataContext;

namespace MyContacts.Providers.Repository
{
    public class ContactsRepository : IContactsRepository
    {        
        private readonly MyContactsDbContext _contactsDbContext;
        public ContactsRepository(MyContactsDbContext contactsDbContext)
        {
            _contactsDbContext = contactsDbContext;
        }
        public Contacts Add(Contacts item)
        {
            _contactsDbContext.Contacts.Add(item);
            _contactsDbContext.SaveChanges();
            return item;
        }

        public Contacts Find(int Id)
        {
            var contactItem = _contactsDbContext.Contacts.Find(Id);
            return contactItem;
        }

        public IEnumerable<Contacts> GetAll()
        {
            return _contactsDbContext.Contacts.ToList();
        }

        public void Remove(int Id)
        {
            var itemToRemove = _contactsDbContext.Contacts.Find(Id);
            if (itemToRemove != null)
                _contactsDbContext.Contacts.Remove(itemToRemove);
            _contactsDbContext.SaveChanges();
        }

        public Contacts Update(Contacts itemToUpdate)
        {   
            if (itemToUpdate != null)
            {
                itemToUpdate.FirstName = itemToUpdate.FirstName;
                itemToUpdate.LastName = itemToUpdate.LastName;
                itemToUpdate.IsFamily = itemToUpdate.IsFamily;                
                itemToUpdate.DateOfBirth = itemToUpdate.DateOfBirth;                
            }
            return itemToUpdate;
        }        
    }
}