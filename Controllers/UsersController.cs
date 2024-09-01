using Microsoft.AspNetCore.Mvc;
using task_Auth.Data;
using task_Auth.Models;

namespace task_Auth.Controllers
{
	public class UsersController : Controller
	{
		private readonly ApplicationDbContext context;

		public UsersController(ApplicationDbContext context)
		{
			this.context = context;
		}
		public IActionResult Index()
		{
			var users=context.Users.Where(user=>user.IsActive==false).ToList();
			return View(users);
		}
		public IActionResult Register()
		{
			return View();
		}
		[HttpPost]
        public IActionResult Register(User user)
        {
           context.Users.Add(user);
			context.SaveChanges();
			return RedirectToAction(nameof(Login));
        }
		public IActionResult Login()
		{
			return View();
		}
        [HttpPost]
        public IActionResult Login(User user)
		{
			var checkUser = context.Users.Where(x => x.UserName == user.UserName && x.Password == user.Password);
			if (checkUser.Any())
			{
				return RedirectToAction(nameof(Index));
			}
			ViewBag.Error = "Invalid UserName or password";
			return View();
		}
		public IActionResult IsActive(Guid UserId)
		{
			var user = context.Users.Find(UserId);
			user.IsActive = true;
			context.SaveChanges();
			return RedirectToAction(nameof(Index));

        }

    }
}
