using BaharFashion.Models;
using BaharFashion.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaharFashion.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ILogger<ShoppingCartController> _logger;
        private ShoppingCart shoppingCart;
        private BaharFashionEntities _context;


        public ShoppingCartController(BaharFashionEntities context)
        {
            _context = context;
            shoppingCart = new ShoppingCart();
            shoppingCart._context = context;
        }

        //
        // GET: /ShoppingCart/
        public ActionResult Index()
        {
            var cart = shoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            
            return View(viewModel);
        }
        
        public ActionResult AddToCart(int id)
        {
            
            var addedGiyim = _context.Giyims
                .Single(giyim => giyim.GiyimId == id);

            
            var cart = shoppingCart.GetCart(this.HttpContext);
            cart.AddToCart(addedGiyim);
            this.HttpContext.Session.SetString("adet", cart.GetCount().ToString());
            

            
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            
            var cart = shoppingCart.GetCart(this.HttpContext);

           
            string giyimName = _context.Carts.Include(p => p.Giyim)
               .Single(item => item.RecordId == id).Giyim.Name;

           
            int itemCount = cart.RemoveFromCart(id);
            this.HttpContext.Session.SetString("adet", cart.GetCount().ToString());
            
            var results = new ShoppingCartRemoveViewModel
            {
                Message = System.Net.WebUtility.HtmlEncode(giyimName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        
        public ActionResult CartSummary()
        {
            var cart = shoppingCart.GetCart(this.HttpContext);
            return PartialView("CartSummary");
        }
        private void MigrateShoppingCart(string UserName)
        {
           
            var cart = shoppingCart.GetCart(this.HttpContext);

            cart.MigrateCart(UserName);
            this.HttpContext.Session.SetString("ShoppingCart.CartSessionKey", UserName);
        } 

    }
}
