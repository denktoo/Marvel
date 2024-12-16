using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Marvel.Data;
using Marvel.Repositories;

namespace Marvel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}