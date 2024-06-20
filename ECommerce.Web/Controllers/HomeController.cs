using Microsoft.AspNetCore.Mvc;
using ECommerce.Services;
using System.Threading.Tasks;

namespace ECommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProducts();
            return View(products);
        }
    }
}
