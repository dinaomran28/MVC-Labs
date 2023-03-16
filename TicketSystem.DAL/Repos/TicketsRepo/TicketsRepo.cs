using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Context;
using TicketSystem.DAL.Models;

namespace TicketSystem.DAL.Repos.TicketsRepo
{
    public class TicketsRepo: ITicketsRepo
    {
        private readonly TicketContext _context;
        public TicketsRepo(TicketContext context)
        {
            _context = context;
        }
        public IEnumerable<Ticket> GetAll()
        {
            return _context.Set<Ticket>();
        }

        //Get The Ticket With Department And Developers
        public Ticket? GetTicketWithDeptAndDevs(int id)
        {
            //return _context.Set<Ticket>().FirstOrDefault(t => t.Id == id); //OR:
            //return _context.Set<Ticket>().Find(id); 
            //Previous Methods Gets the info of ticket only(id,desc,severity,departmentId) not the data of the department so we need to do "join" between the 2 tables by eager loading (include the navigational properties)
            return _context.Set<Ticket>()
                .Include(t => t.Department)
                .Include(t => t.Developers)
                .FirstOrDefault(t => t.Id == id);
        }
        public Ticket? GetTicketWithDevs(int id)
        {
            return _context.Set<Ticket>()
                .Include(t => t.Developers)
                .FirstOrDefault(t => t.Id == id);
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public void Update(Ticket ticket) { }
    }
}
