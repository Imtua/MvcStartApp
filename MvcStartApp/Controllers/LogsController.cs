using Microsoft.AspNetCore.Mvc;
using MvcStartApp.Models.Interfaces;
using System.Threading.Tasks;

namespace MvcStartApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestRepository _repository;

        public LogsController(IRequestRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var requests = await _repository.GetRequestsAsync();
            return View(requests);
        }
    }
}
