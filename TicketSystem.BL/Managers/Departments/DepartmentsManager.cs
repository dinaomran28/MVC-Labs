using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Models;
using TicketSystem.DAL.Repos.DepartmentsRepo;
using TicketSystem.DAL.Repos.DevelopersRepo;

namespace TicketSystem.BL.Managers.Departments
{
    public class DepartmentsManager : IDepartmentsManager
    {
        private readonly IDepartmentsRepo _departmentsRepo;
        public DepartmentsManager(IDepartmentsRepo departmentsRepo)
        {
            _departmentsRepo = departmentsRepo;
        }
        public IEnumerable<SelectListItem> GetDepartmentsListItems()
        {
            List<Department> departmentsFromDB = _departmentsRepo.GetAll().ToList();
            return departmentsFromDB.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
        }
    }
}
