using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyContacts.Entities;
using MyContacts.Providers.DataContext;

namespace MyContacts.Providers.Repository
{
    public class ContactsAsyncRepository : IContactsAsyncRepository
    {        
        private readonly MyContactsDbContext _contactsDbContext;
        public ContactsAsyncRepository(MyContactsDbContext contactsDbContext)
        {
            _contactsDbContext = contactsDbContext;
        }
        public async Task<Contacts> FindAsync(int Id)
        {
            return await _contactsDbContext.Contacts.FindAsync(Id);
        }

        public async Task AddAsync(Contacts item)
        {
            await _contactsDbContext.Contacts.AddAsync(item);
            await _contactsDbContext.SaveChangesAsync();            
        }        

        public async Task<IList<Contacts>> GetAllAsync()
        {
            return await _contactsDbContext.Contacts.ToListAsync();
        }

        public async Task RemoveAsync(int Id)
        {
            var itemToRemove = await _contactsDbContext.Contacts.FindAsync(Id);
            if (itemToRemove != null)
                _contactsDbContext.Contacts.Remove(itemToRemove);
            await _contactsDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contacts itemToUpdate)
        {   
            if (itemToUpdate != null)
            {
                itemToUpdate.FirstName = itemToUpdate.FirstName;
                itemToUpdate.LastName = itemToUpdate.LastName;
                itemToUpdate.IsFamily = itemToUpdate.IsFamily;                
                itemToUpdate.DateOfBirth = itemToUpdate.DateOfBirth;                
            }
            _contactsDbContext.Contacts.Update(itemToUpdate);
            await _contactsDbContext.SaveChangesAsync();            
        }        
    }
}