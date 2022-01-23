using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.ViewModels
{
    public class RegisterVM
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string KontaktBr { get; set; }
        public string DatumRodjenja { get; set; }

        public int GradID { get; set; }
        public List<SelectListItem> Grad { get; set; }
        public int KarticaID { get; set; }
        public List<SelectListItem> Kartica { get; set; }

        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }


    }
}
