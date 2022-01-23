using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.AdministratorModul.ViewModels
{
    public class TipZaposlenikaVM
    {
        public int ID { get; set; }
        public List<Row> rows { get; set; }
        public class Row
        {
            public int TipZaposlenikaID { get; set; }
            public string Naziv { get; set; }
            public string Opis { get; set; }
        }


    }
}
