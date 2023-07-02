using BaharFashion.Models;
using BaharFashion.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BaharFashion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BaharFashionEntities _context;

        public HomeController(ILogger<HomeController> logger, BaharFashionEntities context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            SampleData data = new SampleData(_context);
            data.AddTurs();
            data.AddMarkas();
            data.AddGiyims();

            //git tur tablosundan herşeyi çek.
            var turs = _context.Turs.ToList(); //dbye git tur tablosundan butun kayıtları çek gel.
            return View(turs);
            //return View("Hata"); //yeni eklenen bir sayfayı açsın istersek bu şekilde yazarız.     
            
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