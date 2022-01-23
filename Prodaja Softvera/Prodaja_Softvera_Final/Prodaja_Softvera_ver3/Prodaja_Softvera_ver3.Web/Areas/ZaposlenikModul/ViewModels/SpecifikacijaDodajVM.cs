using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.ZaposlenikModul.ViewModels
{
    public class SpecifikacijaDodajVM
    {
        public int SpecifikacijeID { get; set; }
        public string Naziv { get; set; }

        public int OSID { get; set; }
        public List<SelectListItem> OS { get; set; }

        public int HDDID { get; set; }
        public List<SelectListItem> HDD { get; set; }

        public int CPUId { get; set; }
        public List<SelectListItem> CPU { get; set; }

        public int GPUID { get; set; }
        public List<SelectListItem> GPU { get; set; }

        public int RAMID { get; set; }
        public List<SelectListItem> RAM { get; set; }
    }
}
