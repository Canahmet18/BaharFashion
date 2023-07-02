using BaharFashion.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaharFashion.ViewComponents
{
    public class Sepet : ViewComponent
    {
        private ShoppingCart shoppingCart;
        private readonly BaharFashionEntities _context;

        public Sepet(BaharFashionEntities context)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            _context = context;
            shoppingCart._context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            int adet;
            string deger = HttpContext?.Session.GetString("adet");

            if (deger == null)
            {
                adet = 0;
            }
            else
            {
                adet = int.Parse(HttpContext?.Session.GetString("adet"));
            }
            return View(adet);
        }
    }
}
