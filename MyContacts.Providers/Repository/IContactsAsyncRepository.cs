﻿using MyContacts.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyContacts.Providers.Repository
{
    public interface IContactsAsyncRepository
    {
        Task<Contacts> AddAsync(Contacts item);
        Task<IList<Contacts>> GetAllAsync();
        Task<Contacts> FindAsync(int id);
        Task RemoveAsync(int Id);
        Task<Contacts> UpdateAsync(Contacts item);
    }
}