using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Context;
using TicketSystem.DAL.Models;

namespace TicketSystem.DAL.Repos.DevelopersRepo
{
    public class DevelopersRepo : IDevelopersRepo
    {
        private readonly TicketContext _context;
        public DevelopersRepo(TicketContext context)
        {
            _context = context;
        }
        public IEnumerable<Developer> GetAll()
        {
            return _context.Set<Developer>();
        }
    }
}
