using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.AdministratorModul.ViewModels
{
    public class ZaposlenikUrediViewModel
    {
        public int ZaposlenikID { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Kontakt_br { get; set; }
        public string Datum_rodjenja { get; set; }

        public int GradID { get; set; }
        public List<SelectListItem> Grad { get; set; }
        public int FakultetID { get; set; }
        public List<SelectListItem> Fakultet { get; set; }
        public int TipZaposlenikaID { get; set; }
        public List<SelectListItem> TipZaposlenika { get; set; }

        public int? KorisnickiNalogID { get; set; }
        public List<SelectListItem> KorisnickiNalog { get; set; }
    }
}
