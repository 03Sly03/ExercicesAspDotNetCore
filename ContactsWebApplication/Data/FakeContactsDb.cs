using ContactsWebApplication.Models;

namespace ContactsWebApplication.Data
{
    public class FakeContactsDb
    {
        private List<Contact> _contacts;

        public FakeContactsDb() 
        {
            _contacts = new List<Contact>()
            {
                new Contact()
                {
                    Id = 1,
                    Lastname = "Doe",
                    Firstname = "John",
                    Email = "john@doe.com",
                    Phone = "0612457889",
                    Address = "10 rue de la Marrée",
                    City = "Loos"
                },
                new Contact()
                {
                    Id = 2,
                    Lastname = "Carte",
                    Firstname = "Valentine",
                    Email = "val@entine.com",
                    Phone = "0756231545",
                    Address = "51 rue de la route",
                    City = "Lille"
                },
                new Contact()
                {
                    Id = 3,
                    Lastname = "Mig",
                    Firstname = "Donald",
                    Email = "do@nald.com",
                    Phone = "0789562312",
                    Address = "89 boulevard de bouvard",
                    City = "Lens"
                },
                new Contact()
                {
                    Id = 4,
                    Lastname = "Dinette",
                    Firstname = "Pascale",
                    Email = "pas@cal.com",
                    Phone = "0689784556",
                    Address = "1 avenue de la liberty",
                    City = "Marseille"
                },
                new Contact()
                {
                    Id = 5,
                    Lastname = "Aert",
                    Firstname = "Mikael",
                    Email = "mick@ael.com",
                    Phone = "0623564878",
                    Address = "26 rue de la Saonne",
                    City = "Paris"
                },
            };
        }

        public List<Contact> GetAll()
        {
            return _contacts;
        }

        public Contact? GetById(int id)
        {
            return _contacts.FirstOrDefault(c=> c.Id == id);
        }

        public bool Add(Contact contact)
        {
            _contacts.Add(contact);
            return true;
        }

        public bool Edit(Contact contact)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var contact = GetById(id);
            if (contact == null)
                return false;
            _contacts.Remove(contact);
            return true;
        }
    }
}
