using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.ViewModels.Ticket;
using TicketSystem.DAL.Models;
using TicketSystem.DAL.Repos.DevelopersRepo;
using TicketSystem.DAL.Repos.TicketsRepo;

namespace TicketSystem.BL.Managers.Tickets
{
    public class TicketsManager : ITicketsManager
    {
        private readonly ITicketsRepo _ticketsRepo;
        private readonly IDevelopersRepo _developersRepo;

        public TicketsManager(ITicketsRepo ticketsRepo, IDevelopersRepo developersRepo)
        {
            _ticketsRepo = ticketsRepo;
            _developersRepo = developersRepo;
        }
        public List<TicketReadVM> GetAll()
        {
            var tickets = _ticketsRepo.GetAll(); //list of Ticket, we have to convert it to list of TicketReadVM
            return tickets.Select(t => new TicketReadVM(t.Id, t.Description, t.Severity)).ToList();
        }
        public TicketDetailsVM? GetDetails(int id)
        {
            var ticketFromDB = _ticketsRepo.GetTicketWithDeptAndDevs(id);
            if (ticketFromDB is null)
            {
                return null;
            }
            return new TicketDetailsVM
                (
                    Id: ticketFromDB.Id,
                    Severity: ticketFromDB.Severity,
                    Description: ticketFromDB.Description,
                    DevelopersCount: ticketFromDB.Developers.Count,
                    DepartmentName: ticketFromDB.Department?.Name ?? "" //Or ticketFromDB.Department!.Name
                );
        }
        public TicketEditVM? GetForEdit(int id)
        {
            //var ticketFromDB = _ticketsRepo.Get(id); //We don't need the DepartmentId to be included in the Join so we have to change this Get function to enhance the performance
            var ticketFromDB = _ticketsRepo.GetTicketWithDevs(id);
            if (ticketFromDB is null)
            {
                return null;
            }
            return new TicketEditVM
                (
                    Id: ticketFromDB.Id,
                    Description: ticketFromDB.Description,
                    Severity: ticketFromDB.Severity,
                    DepartmentId: ticketFromDB.DepartmentId,
                    DevelopersIds: ticketFromDB.Developers.Select(d => d.Id).ToArray()
                );
        }
        public int Update(TicketEditVM ticketVM)
        {
            Ticket? entityToUpdate = _ticketsRepo.GetTicketWithDevs(ticketVM.Id);
            if(entityToUpdate is null)
            {
                return 0;
            }
            entityToUpdate!.Severity = ticketVM.Severity;
            entityToUpdate.Description = ticketVM.Description;
            entityToUpdate.DepartmentId = ticketVM.DepartmentId;
            entityToUpdate.Developers = GetDevelopersByIds(ticketVM.DevelopersIds);
            _ticketsRepo.Update(entityToUpdate);
            return _ticketsRepo.Save();
        }
        private ICollection<Developer> GetDevelopersByIds(int[] developersIds)
        {
            var developers = _developersRepo.GetAll();
            return developers.Where(d => developersIds.Contains(d.Id)).ToList();
        }
    }
}
