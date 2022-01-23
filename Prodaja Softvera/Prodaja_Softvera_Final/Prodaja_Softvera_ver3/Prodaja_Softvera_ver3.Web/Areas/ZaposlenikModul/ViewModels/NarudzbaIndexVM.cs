using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.ZaposlenikModul.ViewModels
{
    public class NarudzbaIndexVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public int NarudzbaID { get; set; }
            public DateTime Datum_narudzbe { get; set; }
            public string Komentar { get; set; }

            public int? Ocjena { get; set; }

            public string Klijent { get; set; }
            public string Softver { get; set; }

            public string Racun { get; set; }

        }
    } 
}
