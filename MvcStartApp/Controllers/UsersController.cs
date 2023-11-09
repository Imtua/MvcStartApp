using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Db;
using MvcStartApp.Models.Interfaces;
using System;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IBlogRepository _repository;

        public UsersController(IBlogRepository repository)
        {
             _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _repository.GetUsersAsync();
            return View(authors);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            await _repository.AddUserAsync(user);
            return View(user);
        }
    }
}
