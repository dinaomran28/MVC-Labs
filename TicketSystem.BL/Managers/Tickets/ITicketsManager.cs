using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.BL.ViewModels.Ticket;

namespace TicketSystem.BL.Managers.Tickets
{
    public interface ITicketsManager
    {
        List<TicketReadVM> GetAll();
        TicketDetailsVM? GetDetails(int id);
        TicketEditVM? GetForEdit(int id);
        int Update(TicketEditVM ticketVM);
    }
}
