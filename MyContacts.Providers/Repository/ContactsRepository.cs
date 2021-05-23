using Bogus;
using MyContacts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyContacts.Providers.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private static List<Contacts> demoContactsList = new List<Contacts>();
        public Contacts Add(Contacts item)
        {
            item.Id = new Random().Next(1001, 2000);
            demoContactsList.Add(item);
            return item;
        }

        public Contacts Find(int Id)
        {
            var contactItem = demoContactsList.Find(e => e.Id == Id);
            return contactItem;
        }

        public IEnumerable<Contacts> GetAll()
        {
            demoContactsList = FakeContacts().Generate(10);
            return demoContactsList;
        }

        public void Remove(int Id)
        {
            var itemToRemove = demoContactsList.SingleOrDefault(r => r.Id == Id);
            if (itemToRemove != null)
                demoContactsList.Remove(itemToRemove);
        }

        public Contacts Update(Contacts item)
        {
            var itemToUpdate = demoContactsList.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.FirstName = item.FirstName;
                itemToUpdate.LastName = item.LastName;
                itemToUpdate.IsFamily = item.IsFamily;                
                itemToUpdate.DateOfBirth = item.DateOfBirth;                
            }
            return itemToUpdate;
        }

        #region FakeData
        private List<ContactEmails> FakeContactEmails()
        {
            var fakeContactEmails = new Faker<ContactEmails>()
                .RuleFor(c => c.Id, f => f.IndexVariable++)
                .RuleFor(c => c.Email, (f, u) => f.Internet.Email())
                .RuleFor(c => c.IsPrimary, f => f.Random.Bool());

            return fakeContactEmails.Generate(4);
        }

        private List<ContactPhones> FakeContactPhones()
        {
            var fakeContactEmails = new Faker<ContactPhones>()
                .RuleFor(c => c.Id, f => f.IndexVariable++)
                .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
                .RuleFor(c=> c.Type, f => f.PickRandom<PhoneType>())
                .RuleFor(c => c.IsPrimary, f => f.Random.Bool());

            return fakeContactEmails.Generate(4);
        }

        private Faker<Contacts> FakeContacts()
        {
            var fakeContact = new Faker<Contacts>()
                .RuleFor(c => c.Id, f => f.Random.Number(1, 1000))
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.City, f => f.Address.City())
                .RuleFor(c => c.DateOfBirth, f => f.Date.Past())
                .RuleFor(c => c.EmailAddresses, f => FakeContactEmails())
                .RuleFor(c => c.PhoneNumbers, f => FakeContactPhones());

            return fakeContact;
        }
        #endregion
    }
}