using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.AdministratorModul.ViewModels
{
    public class UrediVM
    {
        public int KlijentID { get; set; }
        public string Naziv { get; set; }

        public string Adresa { get; set; }

        public string Email { get; set; }

        public string Kontakt_broj { get; set; }

        public string Datum_rodjenja { get; set; }

        public int GradID { get; set; }
        public List<SelectListItem> Grad { get; set; }

        public int TipKlijentaID { get; set; }
        public List<SelectListItem> TipKlijenta { get; set; }
    }
}
