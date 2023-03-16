using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Models;

namespace TicketSystem.BL.ViewModels.Ticket
{
    public record TicketEditVM
        (
            int Id, string Description, Severity Severity,
            int DepartmentId,
            int[] DevelopersIds
        );
}