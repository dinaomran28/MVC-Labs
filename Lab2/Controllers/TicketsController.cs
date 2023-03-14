using Lab2.Models.Domain;
using Lab2.Models.View;
using Microsoft.AspNetCore.Mvc;

namespace Lab2.Controllers
{
    public class TicketsController : Controller
    {
        public IActionResult Index()
        {
            var tickets = Ticket.GetTicketsList();
            return View(tickets);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddTicketVM ticketVM)
        {
            var tickets = Ticket.GetTicketsList();

            var ticketToAdd = new Ticket { 
                Id = Guid.NewGuid(),
                CreatedDate= DateTime.Now,
                Description = ticketVM.Description,
                IsClosed= ticketVM.IsClosed,
                Severity = ticketVM.Severity
            };

            tickets.Add(ticketToAdd);
            return RedirectToAction(nameof(Index));
        }
    }
}
