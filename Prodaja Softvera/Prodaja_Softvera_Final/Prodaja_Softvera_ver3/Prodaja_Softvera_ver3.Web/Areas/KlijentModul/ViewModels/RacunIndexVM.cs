using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.KlijentModul.ViewModels
{
    public class RacunIndexVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public int RacunID { get; set; }
            public DateTime Datum { get; set; }
            public double Cijena { get; set; }


        }
    }
}
