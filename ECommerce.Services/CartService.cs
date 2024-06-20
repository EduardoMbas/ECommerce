// Services/CartService.cs
using ECommerce.Core.Models;

namespace ECommerce.Services
{
    public class CartService
    {
        private readonly List<CartItem> _cartItems;

        public CartService()
        {
            _cartItems = new List<CartItem>();
        }

        public void AddToCart(Product product, int quantity)
        {
            var cartItem = _cartItems.FirstOrDefault(ci => ci.Product.Id == product.Id);
            if (cartItem == null)
            {
                _cartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                cartItem.Quantity += quantity;
            }
        }
        public int GetCartItemsCount()
        {
            return _cartItems.Sum(ci => ci.Quantity);
        }

        public decimal GetCartTotalPrice()
        {
            return _cartItems.Sum(ci => ci.Quantity * ci.Product.Price);
        }

        public IEnumerable<CartItem> GetCartItems()
        {
            return _cartItems;
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }
    }
}
