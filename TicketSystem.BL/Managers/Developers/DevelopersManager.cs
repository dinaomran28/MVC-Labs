using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSystem.DAL.Models;
using TicketSystem.DAL.Repos.DevelopersRepo;
using TicketSystem.DAL.Repos.TicketsRepo;

namespace TicketSystem.BL.Managers.Developers
{
    public class DevelopersManager: IDevelopersManager
    {
        private readonly IDevelopersRepo _developersRepo;

        public DevelopersManager(IDevelopersRepo developersRepo)
        {
            _developersRepo = developersRepo;
        }
        public IEnumerable<SelectListItem> GetDevelopersListItems()
        {
            List<Developer> developersFromDB = _developersRepo.GetAll().ToList();
            return developersFromDB.Select(d => new SelectListItem(d.Name, d.Id.ToString()));
        }
    }
}
