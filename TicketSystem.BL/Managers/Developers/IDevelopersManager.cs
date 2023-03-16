using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSystem.BL.Managers.Developers
{
    public interface IDevelopersManager
    {
        //SelectListItem needs a package (MVC.ViewFeatures) to be installed in BL Project
        IEnumerable<SelectListItem> GetDevelopersListItems();
    }
}
