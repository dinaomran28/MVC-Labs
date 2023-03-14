using Lab2.Models;
using Lab2.Models.Domain;
using Lab2.Models.View;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lab2.Controllers
{
    public class TicketsController : Controller
    {
        private static readonly List<Ticket> _tickets = Ticket.GetTicketsList(); //To print, add, update and delete to this static list(data saved in memory only)
        
        private static ICollection<Developer> GetDevelopersByIds(ICollection<Guid> ticketsIds)
        {
            var developers = Developer.GetDevelopers();
            return developers.Where(d => ticketsIds.Contains(d.Id)).ToList();
        }
        private void GetFormDataReady()
        {
            var departments = Department.GetDepartments();
            var developers = Developer.GetDevelopers();

            var selectListItems = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
            ViewData[MagicStrings.Departments] = selectListItems;

            var selectListItemsDev = developers.Select(d => new SelectListItem($"{d.FirstName} {d.LastName}", d.Id.ToString()));
            ViewData[MagicStrings.Developers] = selectListItemsDev;
        }
        public IActionResult Index()
        {
            //var tickets = Ticket.GetTicketsList();
            return View(_tickets);
        }
        [HttpGet]
        public IActionResult Add()
        {
            //var departments = Department.GetDepartments();
            //var developers = Developer.GetDevelopers();
            ////ViewData[MagicStrings.Departments] = departments;
            ////ViewData[MagicStrings.Developers] = developers;

            //var selectListItems = departments.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
            //ViewData[MagicStrings.Departments] = selectListItems;

            //var selectListItemsDev = developers.Select(d => new SelectListItem($"{d.FirstName} {d.LastName}", d.Id.ToString()));
            //ViewData[MagicStrings.Developers] = selectListItemsDev;

            GetFormDataReady();
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddTicketVM ticketVM)
        {
            //var developers = Developer.GetDevelopers();
            //var selectedDevelopersIds = ticketVM.DevelopersIds;
            //var selectedDevelopers = developers.Where(d => selectedDevelopersIds.Contains(d.Id)).ToList();
            ICollection<Developer> selectedDevelopers = GetDevelopersByIds(ticketVM.DevelopersIds);

            var ticketToAdd = new Ticket { 
                Id = Guid.NewGuid(),
                CreatedDate= DateTime.Now,
                Description = ticketVM.Description,
                IsClosed= ticketVM.IsClosed,
                Severity = ticketVM.Severity,
                Department = Department.GetDepartments().First(d => d.Id == ticketVM.DepartmentId),
                Developers = selectedDevelopers
            };

            _tickets.Add(ticketToAdd);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var ticketToEdit = _tickets.First(t => t.Id == id);
            var ticketVM = new EditTicketVM
            {
                Id = ticketToEdit.Id,
                IsClosed = ticketToEdit.IsClosed,
                Description = ticketToEdit.Description,
                Severity = ticketToEdit.Severity,
                //TODO: Why is this line commented
                //DepartmentId = ticketToEdit.Department.Id,
                DevelopersIds = ticketToEdit.Developers.Select(t => t.Id).ToList(),
            };
            GetFormDataReady();
            return View(ticketVM);
        }

        [HttpPost]
        public IActionResult Edit(EditTicketVM ticketVM)
        {
            List<Developer> selectedDevelopers = (List<Developer>)GetDevelopersByIds(ticketVM.DevelopersIds);

            var ticketToEdit = _tickets.First(t => t.Id == ticketVM.Id);
            ticketToEdit.Severity = ticketVM.Severity;
            ticketToEdit.IsClosed = ticketVM.IsClosed;
            //TODO: You forgot Description, that's normal, we will know hot overcome this issue
            ticketToEdit.Department = Department.GetDepartments().First(d => d.Id == ticketVM.DepartmentId);
            ticketToEdit.Developers = selectedDevelopers;

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Delete(Guid id)
        {   
            var ticketToDelete = _tickets.First(t => t.Id == id);
            _tickets.Remove(ticketToDelete);
            return RedirectToAction(nameof(Index));
        }
    }
}
