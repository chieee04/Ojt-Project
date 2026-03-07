using Microsoft.AspNetCore.Mvc;

namespace MyTodoProject.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult LoginPage()
        {
            return View();
        }
        public IActionResult AdminDashboard()
        {
            return View();

        }
        public IActionResult NormalUserDashboard()
        {
            return View();

        }

    }
}
