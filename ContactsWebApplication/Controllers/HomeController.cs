using ContactsWebApplication.Data;
using ContactsWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ContactsWebApplication.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;

        private readonly FakeContactsDb _fakeContactsDb;
        //}
        public HomeController(FakeContactsDb contacts) 
        {
            _fakeContactsDb = contacts;
        }

        public string GetContacts()
        {
            string nomContact = "";
            foreach (var contact in _fakeContactsDb.GetAll())
            {
                nomContact +=  ' ' + contact.Firstname;
            }
            return nomContact;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}