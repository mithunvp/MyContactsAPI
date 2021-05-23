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
        public List<ContactEmails> EmailAddresses { get; set; } = new();
        public List<ContactPhones> PhoneNumbers { get; set; } = new();
        public DateTime DateOfBirth { get; set; }        
    }
}