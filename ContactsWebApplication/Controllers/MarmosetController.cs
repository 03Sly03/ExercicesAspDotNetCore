using ContactsWebApplication.Data;
using ContactsWebApplication.Models;
using ContactsWebApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult DisplayAddForm()
        {
            return View("Add");
        }
        public IActionResult SendMarmoset(Marmoset marmoset)
        {
            _marmosetRepository.Add(marmoset);
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public static string RandomString(string chars, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
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
            var marmoset = _marmosetRepository.GetById(id)!;
            _marmosetRepository.Delete(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
