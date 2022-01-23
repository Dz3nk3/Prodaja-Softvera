using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.ViewModels
{
    public class SoftverUrediViewModel
    {
        public int SoftverID { get; set; }
        [Required]
        public string Naziv { get; set; }
        [Required]
        public string Verzija { get; set; }
        public double cijena { get; set; }
        public IFormFile file { get; set; }

        public int TipSoftveraID { get; set; }
        public List<SelectListItem> TipSoftvera { get; set; }
        public int SpecifikacijeID { get; set; }
        public List<SelectListItem> Specifikacije { get; set; }
    }
}
