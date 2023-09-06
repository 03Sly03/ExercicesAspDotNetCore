using ContactsWebApplication.Models;
using System.Security.Cryptography.X509Certificates;

namespace ContactsWebApplication.Data
{
    public class FakeMarmosetDb
    {
        private List<Marmoset> _marmosetList;

        public FakeMarmosetDb()
        {
            _marmosetList = new List<Marmoset>()
            {
                new Marmoset()
                {
                    Name = "Pick",
                    Age = 1
                },
                new Marmoset()
                {
                    Name = "Azer",
                    Age = 3
                },
                new Marmoset()
                {
                    Name = "Poiu",
                    Age = 5
                },
                new Marmoset()
                {
                    Name = "Vioc",
                    Age = 15
                },
                new Marmoset()
                {
                    Name = "Loupe",
                    Age = 8
                },
                new Marmoset()
                {
                    Name = "Qui",
                    Age = 6
                },
                new Marmoset()
                {
                    Name = "Quoi",
                    Age = 4
                },
                new Marmoset()
                {
                    Name = "Comment",
                    Age = 12
                }
            };
        }
        public List<Marmoset> GetAll()
        {
            return _marmosetList;
        }

        public Marmoset? GetById(int id)
        {
            return _marmosetList.FirstOrDefault(marmoset => marmoset.Id == id);
        }

        public bool Add(Marmoset marmoset)
        {
            _marmosetList.Add(marmoset);
            return true;
        }

        public bool Delete(int id)
        {
            var marmoset = GetById(id);
            if (marmoset == null)
                return false;
            _marmosetList.Remove(marmoset);
            return true;
        }
    }
}
