using ContactsWebApplication.Data;
using ContactsWebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApplication.Controllers
{

    public class ContactController : Controller
    {
        private FakeContactsDb _fakeContactsDb;

        public ContactController(FakeContactsDb contacts) 
        { 
            _fakeContactsDb = contacts;
        }

        public IActionResult Index()
        {
            List<Contact> contacts = _fakeContactsDb.GetAll();
            return View(contacts);
        }

        public IActionResult Details(int id)
        {
        var contact = _fakeContactsDb.GetById(id);
            return View(contact);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Delete(int id) 
        {
            _fakeContactsDb.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public static string RandomString(string chars, int length)
        {
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
