using Microsoft.AspNetCore.Mvc;
using TicketSystem.BL.Managers.Departments;
using TicketSystem.BL.Managers.Developers;
using TicketSystem.BL.Managers.Tickets;
using TicketSystem.BL.ViewModels.Ticket;

namespace TicketSystem.MVC.Controllers
{
    public class TicketsController : Controller
    {
        private readonly ITicketsManager _ticketsManager;
        private readonly IDevelopersManager _developersManager;
        private readonly IDepartmentsManager _departmentsManager;
        public TicketsController(ITicketsManager ticketsManager, IDevelopersManager developersManager, IDepartmentsManager departmentsManager)
        {
            _ticketsManager = ticketsManager;
            _developersManager = developersManager;
            _departmentsManager = departmentsManager;
        }
        public IActionResult Index()
        {
            var tickets = _ticketsManager.GetAll();
            return View(tickets);
        }

        [Route("/Tickets/Details/{id}/{rows}")]
        [Route("/Tickets/Details/{id}")]
        public IActionResult Details(int id, int rows)
        {
            TicketDetailsVM? ticketVM = _ticketsManager.GetDetails(id);
            if(ticketVM is null)
            {
                return NotFound(); // 404 error from browser
            }
            var data = new { ticketVM, rows };
            return View(data);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var ticketVM = _ticketsManager.GetForEdit(id);
            ViewBag.DepartmentId = _departmentsManager.GetDepartmentsListItems();
            ViewBag.Developers = _developersManager.GetDevelopersListItems();
            return View(ticketVM);
        }
        [HttpPost]
        public IActionResult Edit(TicketEditVM ticketVM)
        {
            var rowsAffected = _ticketsManager.Update(ticketVM);
            return RedirectToAction(nameof(Details), new { id = ticketVM.Id, rows = rowsAffected });
        }
    }
}
