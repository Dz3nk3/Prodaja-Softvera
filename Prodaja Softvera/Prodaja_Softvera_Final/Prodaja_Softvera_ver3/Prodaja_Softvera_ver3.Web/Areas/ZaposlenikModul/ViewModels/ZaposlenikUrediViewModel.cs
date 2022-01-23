using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.ViewModels
{
    public class ZaposlenikUrediViewModel
    {
        public int ZaposlenikID { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Kontakt_br { get; set; }
        [Required]
        public string Datum_rodjenja { get; set; }
        [Required]
        [StringLength(1)]
        public string Spol { get; set; }
        public int GradID { get; set; }
        public List<SelectListItem> Grad { get; set; }
        public int FakultetID { get; set; }
        public List<SelectListItem> Fakultet { get; set; }
        public int TipZaposlenikaID { get; set; }
        public List<SelectListItem> TipZaposlenika { get; set; }
    }
}
