using Microsoft.AspNetCore.Mvc;

namespace turismoTCC.Controllers
{


    public class MasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
