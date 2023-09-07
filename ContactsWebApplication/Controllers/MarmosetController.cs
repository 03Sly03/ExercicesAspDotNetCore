using ContactsWebApplication.Data;
using ContactsWebApplication.Models;
using ContactsWebApplication.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ContactsWebApplication.Controllers
{
    public class MarmosetController : Controller
    {
        private IRepository<Marmoset> _marmosetRepository;
        public MarmosetController(IRepository<Marmoset> marmosetRepository) 
        {
            _marmosetRepository = marmosetRepository;
        }

        public IActionResult Index()
        {
            List<Marmoset> marmosetList = _marmosetRepository.GetAll();
            return View(marmosetList);
        }

        public IActionResult Details(int id)
        {
            var marmoset = _marmosetRepository.GetById(id);
            return View(marmoset);
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult Update(int id)
        {
            var marmoset = _marmosetRepository.GetById(id);
            if (marmoset == null)
                return View("Error");
            else
                _marmosetRepository.Update(marmoset);
            return View("Add", marmoset);
        }

        public IActionResult Submit(Marmoset marmoset)
        {
            if (marmoset.Id == 0)
                _marmosetRepository.Add(marmoset);
            else
                _marmosetRepository.Update(marmoset);
            return RedirectToAction("Index");
        }

        [NonAction]
        public static string RandomString(string chars, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public IActionResult Favoris()
        {
            var favListIdOfMarmoset = _GetFavoris();
            List<Marmoset> favListOfMarmoset = new List<Marmoset>();
            foreach (int id in favListIdOfMarmoset)
            {
                var marmoset = _marmosetRepository.GetById(id);
                if (marmoset != null)
                    favListOfMarmoset.Add(marmoset);
            }
            return View(favListOfMarmoset);
        }

        public IActionResult AddToFav(int id) 
        {
            List<int> favIdsMarmoset = _GetFavoris();
            favIdsMarmoset.Add(id);

            string? favCookie = JsonSerializer.Serialize(favIdsMarmoset);

            //HttpContext.Response.Cookies.Append("ouistitiFavoris", favCookie); // enregistrement via cookies
            HttpContext.Session.SetString("myFavorite", favCookie); // enregistrement via session (côté serveur)
            return RedirectToAction(nameof(Index));
            
        }
        
        private List<int> _GetFavoris() // retournera la liste des ouisitis favoris depuis COOKIES ou SESSION
        {
            List<int> favIdsMarmoset = new List<int>();

            // récup d'un cookie
            //string? favCookie = HttpContext.Request.Cookies["ouistitiFavoris"]; // sous forme de chaine de caractères (depuis la requête entrante)
            string? favCookie = HttpContext.Session.GetString("myFavorite"); // sous forme de chaine de caractères (depuis la requête entrante)

            if (favCookie != null)
                favIdsMarmoset = JsonSerializer.Deserialize<List<int>>(favCookie)!;
            return favIdsMarmoset;
        }

        public IActionResult CreateRandom(Marmoset marmoset)
        {
            Random random = new Random();
            int age = random.Next(1, 26);
            marmoset = new Marmoset()
            {
                Name = RandomString("abcdefghijklmnopqrstuvwxyz", random.Next(3, 10)),
                Age = age
            };
            _marmosetRepository.Add(marmoset);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            if (_marmosetRepository.GetById(id) == null)
            {

            }
            var marmoset = _marmosetRepository.GetById(id)!;
            _marmosetRepository.Delete(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
