using Microsoft.AspNetCore.Mvc;
using MyTodoProject.Models;
using MyTodoProject.Repo;

namespace MyTodoProject.Controllers
{
    public class ItemsController : Controller
    {
        private readonly UserRepo _repo;
        private readonly TaskRepo _taskRepo;

        public ItemsController(UserRepo repo, TaskRepo taskRepo)
        {
            _repo = repo;
            _taskRepo = taskRepo;
        }

        public IActionResult LoginPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _repo.Login(username, password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("userID", user.userID);
                HttpContext.Session.SetString("role", user.role);

                return RedirectToAction("AdminDashboard");
            }

            return View("LoginPage");
        }

        public IActionResult AdminDashboard()
        {
            var userID = HttpContext.Session.GetInt32("userID");

            if (userID == null)
                return RedirectToAction("LoginPage");

            var role = HttpContext.Session.GetString("role");

            ViewBag.Role = role;

            ViewBag.PersonalTasks = _taskRepo.GetPersonalTasks(userID.Value);

            if (role == "admin")
                ViewBag.UserTasks = _taskRepo.GetAllUserTasks();

            return View();
        }

        [HttpPost]
        public IActionResult CreateTask(string title, string description)
        {
            var userID = HttpContext.Session.GetInt32("userID");

            Tasks task = new Tasks
            {
                userID = userID.Value,
                title = title,
                description = description
            };

            _taskRepo.AddTask(task);

            return RedirectToAction("AdminDashboard");
        }

        [HttpPost]
        public IActionResult UpdateTask(int taskID, string title, string description)
        {
            Tasks task = new Tasks
            {
                taskID = taskID,
                title = title,
                description = description
            };

            _taskRepo.UpdateTask(task);

            return RedirectToAction("AdminDashboard");
        }

        public IActionResult DeleteTask(int id)
        {
            _taskRepo.DeleteTask(id);
            return RedirectToAction("AdminDashboard");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginPage");
        }
    }
}