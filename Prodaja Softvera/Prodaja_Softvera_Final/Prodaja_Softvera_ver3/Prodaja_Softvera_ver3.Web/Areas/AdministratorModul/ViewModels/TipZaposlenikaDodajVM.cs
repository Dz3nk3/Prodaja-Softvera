using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.AdministratorModul.ViewModels
{
    public class TipZaposlenikaDodajVM
    {
        public int TipZaposlenikaID { get; set; }
        public List<SelectListItem> TipZaposlenika { get; set; }


        public int GradID { get; set; }
        public List<SelectListItem> Grad { get; set; }



        public int FakultetID { get; set; }
        public List<SelectListItem> Fakultet { get; set; }



        public int DrzavaID { get; set; }
        public List<SelectListItem> Drzava { get; set; }
    }
}
