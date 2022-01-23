using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.ZaposlenikModul.ViewModels
{
    public class AnalizaDodajVM
    {
        public int AnalizaID { get; set; }

        public string Naziv { get; set; }
        public DateTime Datum_analize { get; set; }

        public int KlijentID { get; set; }
        public List<SelectListItem> Klijent { get; set; }
        public int ZaposlenikID { get; set; }
        public List<SelectListItem> Zaposlenik { get; set; }
        public int SoftverID { get; set; }
        public List<SelectListItem> Softver { get; set; }
    }
}
