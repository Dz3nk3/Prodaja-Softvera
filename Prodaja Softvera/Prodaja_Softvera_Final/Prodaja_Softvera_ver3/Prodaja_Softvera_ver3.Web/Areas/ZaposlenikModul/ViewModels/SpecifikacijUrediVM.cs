using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.ZaposlenikModul.ViewModels
{
    public class SpecifikacijUrediVM
    {
        public int SpecifikacijeID { get; set; }
        public string Naziv { get; set; }
        public string HDD { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string RAM { get; set; }
    }
}
