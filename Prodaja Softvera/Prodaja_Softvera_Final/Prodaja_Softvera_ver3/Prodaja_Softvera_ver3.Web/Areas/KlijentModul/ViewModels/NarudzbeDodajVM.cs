using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.KlijentModul.ViewModels
{
    public class NarudzbeDodajVM
    {
        public int NarudzbaID { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum_narudzbe { get; set; }

        public int KlijentID { get; set; }

        public string Racun { get; set; }
    }
}
