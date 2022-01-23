using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.KlijentModul.ViewModels
{
    public class SoftverNarudzbaKartIndexVM
    {
        public int ID { get; set; }
        public List<Row> rows { get; set; }

        public class Row
        {
            public int SoftverNarudzbaID { get; set; }
            public double CijenaSoftvera { get; set; }
            public string NazivSoftvera { get; set; }
            public DateTime Datum { get; set; }
            public int SoftverID { get; set; }
            public int NarudzbaID { get; set; }
            public int? Ocjena { get; set; }
            public string Komentar { get; set; }
        }
    }
}
