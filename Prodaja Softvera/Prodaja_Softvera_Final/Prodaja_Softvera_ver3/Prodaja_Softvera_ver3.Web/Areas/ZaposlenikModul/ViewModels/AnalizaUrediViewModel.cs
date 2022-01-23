using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.ViewModels
{
    public class AnalizaUrediViewModel
    {

        public int AnalizaID { get; set; }

        [Required]
        public string Naziv { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Datum_analize { get; set; }
        public int KlijentID { get; set; }
        public List<SelectListItem> Klijent { get; set; }
        public int ZaposlenikID { get; set; }
        public List<SelectListItem> Zaposlenik { get; set; }
        public int SoftverID { get; set; }
        public List<SelectListItem> Softver { get; set; }
    }
}
