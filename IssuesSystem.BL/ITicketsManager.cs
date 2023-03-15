using IssuesSystem.BL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.BL
{
    public interface ITicketsManager
    {
        List<TicketReadVM> GetAll();
        TicketReadVM? Get(int id);
        void Add(TicketAddVM ticket);
        void Edit(TicketEditVM ticket,int id);
        void Delete(int id);
    }
}
