using IssuesSystem.DAL.Context;
using IssuesSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.DAL.Repositories
{
    public class TicketsRepo : ITicketsRepo
    {
        private readonly IssuesContext _context;
        public TicketsRepo(IssuesContext context)
        {
            _context = context;
        }
        public IEnumerable<Ticket> GetAll()
        {
            return _context.Set<Ticket>();
        }
        public Ticket? Get(int id)
        {
            return _context.Set<Ticket>().Find(id); //Or by FirstOrDefault()
        }
        public void Add(Ticket ticket)
        {
            //_context.Tickets.Add(ticket);
            _context.Set<Ticket>().Add(ticket); //use Set<Ticket> it is better
        }
        public void Update(Ticket ticket){ }
        public void Delete(int id)
        {
            var ticketToDelete = Get(id);
            if(ticketToDelete != null)
            {
                _context.Set<Ticket>().Remove(ticketToDelete);
            }
        }
        public int SaveChanges()
        {
            return _context.SaveChanges(); //return # of affected rows
        }
    }
}