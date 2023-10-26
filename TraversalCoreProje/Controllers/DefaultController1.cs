using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Controllers
{
    public class DefaultController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
