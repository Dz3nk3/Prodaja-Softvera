using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.ZaposlenikModul.ViewModels
{
    public class TipSoftveraIndexVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public int TipSoftveraID { get; set; }
            public string Naziv { get; set; }
            public string Opis { get; set; }
        }
    }
}
