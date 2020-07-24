using Microsoft.AspNetCore.Mvc;

namespace DL.NetCore.EmptySolution.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
