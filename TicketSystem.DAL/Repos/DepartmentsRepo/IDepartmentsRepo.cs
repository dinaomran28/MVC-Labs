using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Models;

namespace TicketSystem.DAL.Repos.DepartmentsRepo
{
    public interface IDepartmentsRepo
    {
        IEnumerable<Department> GetAll();
    }
}
