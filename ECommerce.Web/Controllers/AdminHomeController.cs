using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin")]
public class AdminHomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ManageProducts()
    {
        return View();
    }
}
