using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BaharFashion.Models
{
    public class ShoppingCart
    {
        public BaharFashionEntities _context;
        string ShoppingCartId { get; set; }

        public const string CartSessionKey = "CartId";

        public ShoppingCart GetCart(HttpContext context)
        {
            var cart = new ShoppingCart();
            cart._context = _context;
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        
        public ShoppingCart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        //sepete ürün ekleme
        public void AddToCart(Giyim giyim)
        {
            
            var cartItem = _context.Carts.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.GiyimId == giyim.GiyimId);

            if (cartItem == null)
            {
              
                cartItem = new Cart
                {
                    GiyimId = giyim.GiyimId,
                    CartId = ShoppingCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                _context.Carts.Add(cartItem);
            }
            else
            {
                
                cartItem.Count++;
            }
           
            _context.SaveChanges();
        }

        //sepetten ürün sil metodu
        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = _context.Carts.Single(
                cart => cart.CartId == ShoppingCartId
                && cart.RecordId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    _context.Carts.Remove(cartItem);
                }
                // Save changes
                _context.SaveChanges();
            }
            return itemCount;
        }

        //sepeti boşalt metodu
        public void EmptyCart()
        {
            var cartItems = _context.Carts.Where(
                cart => cart.CartId == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                _context.Carts.Remove(cartItem);
            }
            // Save changes
            _context.SaveChanges();
        }

        //o kişinin sepetindeki ürünleri getirecek metot.
        public List<Cart> GetCartItems()
        {
            return _context.Carts.Include(p => p.Giyim).Where(cart => cart.CartId == ShoppingCartId).ToList();
        }

        //sepetteki ürünler için toplam adet bilgisini getirecek metot
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in _context.Carts
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Count).Sum();
            
            return count ?? 0; //count isimmli değişkenin değeri null ise 0 değerini ata.
        }

        //toplam tutar.
        public decimal GetTotal()
        {
            
            decimal? total = (from cartItems in _context.Carts
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Count *
                              cartItems.Giyim.Price).Sum();

            return total ?? decimal.Zero; //total değeri null ise varsayılan olarak 0 değerini atar.

        }

        //sipariş oluşturma metodu
        public int CreateOrder(Order order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new OrderDetail
                {
                    GiyimId = item.GiyimId,
                    OrderId = order.OrderId,
                    UnitPrice = item.Giyim.Price,
                    Quantity = item.Count
                };
                // Set the order total of the shopping cart
                orderTotal += (item.Count * item.Giyim.Price);

                _context.OrderDetails.Add(orderDetail);

            }
          
            order.Total = orderTotal;

            
            _context.SaveChanges();
            
            EmptyCart();
            
            return order.OrderId;
        }

        
        public string GetCartId(HttpContext context)
        {
            
            if (context.Session.GetString("CartSessionKey") == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session.SetString("CartSessionKey", context.User.Identity.Name);
                }
                else
                {
                   
                    Guid tempCartId = Guid.NewGuid();
                    
                    context.Session.SetString("CartSessionKey", tempCartId.ToString());
                }
            }
            return context.Session.GetString("CartSessionKey");
        }
        
        public void MigrateCart(string userName)
        {
            var shoppingCart = _context.Carts.Where(
                c => c.CartId == ShoppingCartId);

            foreach (Cart item in shoppingCart)
            {
                item.CartId = userName;
            }
            _context.SaveChanges();
        }
    }
}
