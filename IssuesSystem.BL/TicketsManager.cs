using IssuesSystem.BL.ViewModels;
using IssuesSystem.DAL.Models;
using IssuesSystem.DAL.Repositories;

namespace IssuesSystem.BL
{
    public class TicketsManager : ITicketsManager
    {
        private readonly ITicketsRepo _ticketsRepo;

        public TicketsManager(ITicketsRepo ticketsRepo)
        {
            _ticketsRepo = ticketsRepo;
        }
        public List<TicketReadVM> GetAll()
        {
            var ticketsFromDB = _ticketsRepo.GetAll();
            return ticketsFromDB.Select(t => new TicketReadVM(t.Id, t.Title, t.Description, t.Severity)).ToList();
            //If you want to remote .ToList() make the return type --> IEnumerable<> not List<>
        }
        public TicketReadVM? Get(int id)
        {
            var ticketFromDB = _ticketsRepo.Get(id);
            if(ticketFromDB == null) 
            {
                return null;
            }
            return new TicketReadVM(ticketFromDB.Id, ticketFromDB.Title, ticketFromDB.Description, ticketFromDB.Severity);
        }
        public void Add(TicketAddVM ticketVM)
        {
            var ticket = new Ticket
            {
                Title = ticketVM.Title,
                Description = ticketVM.Description,
                Severity = ticketVM.Severity,
            };
            _ticketsRepo.Add(ticket);
            _ticketsRepo.SaveChanges();
        }
        public void Delete(int id)
        {
            _ticketsRepo.Delete(id);
            _ticketsRepo.SaveChanges();
        }
        public void Edit(TicketEditVM ticketVM, int id)
        {
            var ticket = _ticketsRepo.Get(id);
            if (ticket != null)
            {
                ticket.Title = ticketVM.Title;
                ticket.Description = ticketVM.Description;
                ticket.Severity = ticketVM.Severity;
                _ticketsRepo.Update(ticket);
                _ticketsRepo.SaveChanges();
            }
        }
    }
}
