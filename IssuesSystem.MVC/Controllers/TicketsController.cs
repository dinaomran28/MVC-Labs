using IssuesSystem.BL;
using IssuesSystem.BL.ViewModels;
using IssuesSystem.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace IssuesSystem.MVC.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketsManager _ticketsManager;

        public TicketsController(ITicketsManager ticketsManager) 
        {
            _ticketsManager = ticketsManager;
        }
        public IActionResult Index()
        {
            return View(_ticketsManager.GetAll());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(TicketAddVM ticket)
        {
            _ticketsManager.Add(ticket);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ticketToEdit = _ticketsManager.Get(id);
            return View(ticketToEdit);
        }
        [HttpPost]
        public IActionResult Edit(TicketEditVM ticket, int id)
        {
            _ticketsManager.Edit(ticket, id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            _ticketsManager.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
