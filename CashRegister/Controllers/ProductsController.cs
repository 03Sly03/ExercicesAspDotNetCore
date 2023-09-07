using CashRegister.Data;
using CashRegister.Models;
using CashRegister.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CashRegister.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUploadService _uploadService;

        public ProductsController(ApplicationDbContext dbContext, IUploadService uploadService)
        {
            _dbContext = dbContext;
            _uploadService = uploadService;
        }

        public IActionResult Index()
        {
            return View(_dbContext.Products.ToList());
        }

        public IActionResult Add() 
        {
            return View();
        }

        public IActionResult Update(int id)
        {
            var product = _dbContext.Products.FirstOrDefault(product => product.Id == id);
            if (product == null)
                return View("Error");
            else
                _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
            return View("Add", product);
        }

        public IActionResult Submit(Product product, IFormFile picture)
        {
            if (product.Id == 0)
            {
                product.PicturePath = _uploadService.Upload(picture);
                _dbContext.Products.Add(product);
            }
            else
            {
                if (picture != null)
                    product.PicturePath = _uploadService.Upload(picture);
                //else
                //{
                //    string thePicturePath = _dbContext.Products.Find(product.Id)!.PicturePath!.ToString();
                //    product.PicturePath = thePicturePath;
                //}
                _dbContext.Products.Update(product);
            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
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