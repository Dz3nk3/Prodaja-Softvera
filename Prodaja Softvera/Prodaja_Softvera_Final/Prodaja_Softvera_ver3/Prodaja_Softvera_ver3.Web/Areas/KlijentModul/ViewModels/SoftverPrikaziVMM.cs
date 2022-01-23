using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.ViewModels
{
    public class SoftverPrikaziVMM
    {
        public List<Row> rows;

        public class Row
        {
            public int SoftverID { get; set; }
            public string Naziv { get; set; }
            public string Verzija { get; set; }
            public int cijena { get; set; }
            public string TipSoftvera { get; set; }
            public string Specifikacije { get; set; }
        }
    }
   
}
