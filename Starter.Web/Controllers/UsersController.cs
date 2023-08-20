using FmxLite.Model;
using Microsoft.AspNetCore.Mvc;

namespace FmxLite.Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        private readonly DBContext _context; 

        public UsersController(
            IUserService userService, 
            DBContext context)
        {
            this.userService = userService;
            _context = context; 
        }

        public async Task<IActionResult> Index()
        {
            var users = await  userService.GetAll(); 
            return View(users);
        }

        public async Task<IActionResult> Create()
        {
            var users = await userService.GetAll();
            ViewBag.Users = users;
            return View("Edit", new User());
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                await userService.Add(user);
                return RedirectToAction("Details", new { id = user.Id });
            }

            ViewBag.Users = await userService.GetAll();
            return View("Edit", user);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await userService.Get(id); 
            if (user == null)
                return NotFound();

            return View(user);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var user = await userService.Get(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            var existingUser = await userService.Get(user.Id);
            if (existingUser == null)
                return NotFound();

            existingUser.Name = user.Name;
            existingUser.PhoneNumber = user.PhoneNumber;

            await userService.Update(existingUser);

            return RedirectToAction("Details", new { id = existingUser.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await userService.Get(id);
            if (user == null)
                return NotFound();

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await userService.Get(id);
            if (user == null)
                return NotFound();

            await userService.Delete(user);
            return RedirectToAction(nameof(Index));
        }
    }
}
