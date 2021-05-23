namespace MyContacts.Entities
{
    public class ContactPhones
    {
        public int Id { get; set; }
        public int? ContactId { get; set; }
        public string Phone { get; set; }
        public bool IsPrimary { get; set; }
        public PhoneType Type { get; set; }
        public Contacts Contacts { get; set; }
    }

    public enum PhoneType
    {
        Home,
        Work,
        Emergency,
        Alternate
    }
}
