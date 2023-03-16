using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.BL.Managers.Departments
{
    public interface IDepartmentsManager
    {
        IEnumerable<SelectListItem> GetDepartmentsListItems();
    }
}
