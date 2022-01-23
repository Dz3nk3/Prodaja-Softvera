using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.ZaposlenikModul.ViewModels
{
    public class KlijentUrediVM
    {
        public int KlijentID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string Email { get; set; }

        public string Kontakt_broj { get; set; }

        public string Datum_rodjenja { get; set; }

        public string Grad { get; set; }

        public string BrojKartice { get; set; }
        

    }
}
