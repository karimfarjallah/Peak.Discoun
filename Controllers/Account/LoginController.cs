using Microsoft.AspNetCore.Mvc;

namespace Peak.Discount.Dashboard.Controllers
{

    public class LoginController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }
    }
}
