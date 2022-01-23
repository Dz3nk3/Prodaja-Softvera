using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.ViewModels
{
    public class KlijentUrediViewModel
    {
        public int KlijentID { get; set; }

        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string Email { get; set; }
        public string Kontakt_broj { get; set; }
        public string BrojKartice { get; set; }
        public string Datum_rodjenja { get; set; }
        public int GradID { get; set; }
        public List<SelectListItem> Grad { get; set; }


        public int KarticaID { get; set; }
        public List<SelectListItem> Kartica { get; set; }



        public int? KorisnickiNalogID { get; set; }
        public List<SelectListItem> KorisnickiNalog { get; set; }

    }
}
