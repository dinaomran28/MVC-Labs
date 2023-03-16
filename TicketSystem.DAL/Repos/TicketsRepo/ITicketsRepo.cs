using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Models;

namespace TicketSystem.DAL.Repos.TicketsRepo
{
    public interface ITicketsRepo
    {
        IEnumerable<Ticket> GetAll();
        Ticket? GetTicketWithDeptAndDevs(int id); //Get The Ticket With Department And Developers
        Ticket? GetTicketWithDevs(int id); //Get The Ticket With Developers Only
        int Save();
        void Update(Ticket ticket) { }
    }
}
