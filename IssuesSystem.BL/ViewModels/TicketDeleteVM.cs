using IssuesSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.BL.ViewModels
{
    public record TicketDeleteVM(int Id, string Title, string Description, Severity Severity);
}
