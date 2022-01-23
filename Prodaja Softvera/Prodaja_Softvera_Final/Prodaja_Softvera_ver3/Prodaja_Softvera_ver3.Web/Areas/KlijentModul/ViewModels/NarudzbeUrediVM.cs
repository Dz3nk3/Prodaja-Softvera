using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.KlijentModul.ViewModels
{
    public class NarudzbeUrediVM
    {
        public int NarudzbaID { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum_narudzbe { get; set; }
        public string Komentar { get; set; } // I OVO

        public int Ocjena { get; set; }// ZVEZDICE

        public string Klijent { get; set; }

        public string Racun { get; set; }
    }
}
