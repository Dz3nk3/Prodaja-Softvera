using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.KlijentModul.ViewModels
{
    public class SoftvareKlijentIndexVM
    {
        public int ID { get; set; }
        public List<Row> rows { get; set; }
        public class Row
        {
            public int SoftverID { get; set; }
            public string imgfilename { get; set; }
            public string Naziv { get; set; }
            public string Verzija { get; set; }
            public double Cijena { get; set; }
            public int Ocjena { get; set; }
            public string Komentar { get; set; }

            public string TipSoftvera { get; set; }


            public string Specifikacije { get; set; }

        }
    }
}
