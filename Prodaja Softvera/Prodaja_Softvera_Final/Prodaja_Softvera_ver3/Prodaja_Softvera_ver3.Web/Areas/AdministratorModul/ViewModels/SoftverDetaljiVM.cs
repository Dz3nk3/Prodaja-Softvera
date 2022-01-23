using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.AdministratorModul.ViewModels
{
    public class SoftverDetaljiVM
    {
        public int SoftverID { get; set; }
        public string Naziv { get; set; }
        public string Verzija { get; set; }
        public double Cijena { get; set; }
        public string TipSoftvera { get; set; }
        public string Specifikacija { get; set; }
    }
}
