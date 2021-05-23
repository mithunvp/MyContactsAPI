using System;
using System.Collections.Generic;

namespace MyContacts.Entities
{
    public class Contacts
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsFamily { get; set; }
        public string City { get; set; }        
        public IEnumerable<ContactEmails> EmailAddresses { get; set; }
        public IEnumerable<ContactPhones> PhoneNumbers { get; set; }
        public DateTime DateOfBirth { get; set; }        
    }
}