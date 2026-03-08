using Microsoft.AspNetCore.Mvc;
using MyTodoProject.Repo;

namespace MyTodoProject.Controllers
{
    public class ItemsController : Controller
    {
        private readonly UserRepo _repo;

        public ItemsController(UserRepo repo)
        {
            _repo = repo;
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _repo.Login(username, password);

            if (user == null)
            {
                return View("LoginPage");
            }

            if (user != null) {
                if (user.role == "admin") { return RedirectToAction("AdminDashboard"); }
                if (user.role == "nUser") { return RedirectToAction("NormalUserDashboard"); }
            }
            return View("LoginPage");

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
