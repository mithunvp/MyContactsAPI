using Microsoft.EntityFrameworkCore;
using MyContacts.Entities;

namespace MyContacts.Providers.DataContext
{
    public class MyContactsDbContext : DbContext
    {
        public MyContactsDbContext(DbContextOptions<MyContactsDbContext> options)
            : base(options) { }        
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<ContactEmails> ContactEmails { get; set; }
        public DbSet<ContactPhones> ContactPhones { get; set; }        
    }
}
