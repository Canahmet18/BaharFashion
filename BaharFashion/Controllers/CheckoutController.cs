using BaharFashion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaharFashion.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private ShoppingCart shoppingCart;
        private readonly BaharFashionEntities _context;
        const string PromoCode = "FREE"; //const: constant,  sabit değerli değişken tanımla

        public CheckoutController(BaharFashionEntities context)
        {
            _context = context;
            shoppingCart = new ShoppingCart();
            shoppingCart._context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //AdressAndPayment
        public IActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddressAndPayment(IFormCollection values)
        {
            Order order = new Order(); //yeni bir sipariş girilecek db tarafına bunun için nesneyi ornekledik.
            if (!ModelState.IsValid)
            {
                return View(order);
            }
            string sss = values["Address"]; //formdaki Address alanından değer okuma işlemi

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase) == false)
                {

                    return View(order);
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.FirstName = values["FirstName"];
                    order.LastName = values["LastName"];
                    order.OrderDate = DateTime.Now;
                    order.Address = values["Address"];
                    order.City = values["City"];
                    order.Country = values["Country"];
                    order.Email = values["Email"];
                    order.Phone = values["Phone"];
                    order.State = values["State"];
                    order.PostalCode = values["PostalCode"];
                    order.Total = Convert.ToDecimal(values["Total"]);
                    _context.Orders.Add(order);
                    _context.SaveChanges();

                    var cart = shoppingCart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);
                    //ViewData["CartCount"] = cart.GetCount(); //sepetteki adet bilgisini alır bunu view yapısında göstermek üzere viewdata nesnesine koyar.
                    //this.HttpContext.Session.SetString("adet", cart.GetCount().ToString());
                    return RedirectToAction("Complete", new { id = order.OrderId });
                }
            }
            catch (Exception ex)
            {
                //hatali durum olursa o ana kadar girilmiş olan bilgileri sayfaya döndürür.
                return View(order);
            }
        }


        public IActionResult Complete(int id)
        {
            bool isValid = _context.Orders.Any(kayit => kayit.OrderId == id && kayit.Username == User.Identity.Name);
            if (isValid)
            {
                return View(id);
            }
            else
                return View("Error");
        }


    }
}
