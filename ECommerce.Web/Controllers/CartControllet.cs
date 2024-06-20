// Controllers/CartController.cs
using Microsoft.AspNetCore.Mvc;
using ECommerce.Services;
using ECommerce.Core.Models;

namespace ECommerce.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly CartService _cartService;
        private readonly ProductService _productService;

        public CartController(CartService cartService, ProductService productService)
        {
            _cartService = cartService;
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cartItems = _cartService.GetCartItems();
            return View(cartItems);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var product = _productService.GetProductById(productId).Result; // Assuming GetProductById is an async method
            if (product != null)
            {
                _cartService.AddToCart(product, quantity);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            _cartService.ClearCart();
            return RedirectToAction("Index");
        }
    }
}
