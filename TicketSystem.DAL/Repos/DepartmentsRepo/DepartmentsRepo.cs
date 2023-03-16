using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Context;
using TicketSystem.DAL.Models;

namespace TicketSystem.DAL.Repos.DepartmentsRepo
{
    public class DepartmentsRepo : IDepartmentsRepo
    {
        private readonly TicketContext _context;
        public DepartmentsRepo(TicketContext context)
        {
            _context = context;
        }
        IEnumerable<Department> IDepartmentsRepo.GetAll()
        {
            return _context.Set<Department>();
        }
    }
}
