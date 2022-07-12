using Microsoft.AspNetCore.Mvc;

namespace NC_Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
