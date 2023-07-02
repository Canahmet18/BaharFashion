using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using BaharFashion.Models;
using System.Web;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly BaharFashionEntities _context; //veri tabanına gitmek için

        public StoreController(BaharFashionEntities context)
        {
            _context = context;
        }


        public IActionResult Index(string turid)
        {

           
            int Turid = Int16.Parse(turid);
            List<Kategori> kategoris = _context.Kategoris.Where(p => p.TurId == Turid).ToList();  //veri tabanındaki tür bilgilerini çekip liste haline getirecek kod
            return View(kategoris);
        }

      
        public IActionResult Browse(string kategoriId)
        {
            
            int KategoriId=Int16.Parse(kategoriId);
            List<Giyim> giyimler = _context.Giyims.Where(p =>p.KategoriId== KategoriId).ToList();
            return View(giyimler);
        }
       
        public IActionResult Details(int id)
        {
            //var album = new Album { Title = "Album " + id };
            var giyim = _context.Giyims.Where(kayit => kayit.GiyimId == id).FirstOrDefault();
            return View(giyim);
        }

    }
}
