using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.AdministratorModul.ViewModels
{
    public class FakultetDodajVM
    {
        public int FakultetID { get; set; }
        public int NazivID { get; set; }
        public List<SelectListItem> Naziv { get; set; }
        public int UniverzitetID { get; set; }
        public List<SelectListItem> Univerzitet { get; set; }
    }
}
