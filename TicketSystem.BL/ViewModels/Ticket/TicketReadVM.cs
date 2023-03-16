using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Models;

namespace TicketSystem.BL.ViewModels.Ticket
{
    public record TicketReadVM(int Id, string Description, Severity Severity);
}
