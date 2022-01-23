using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.ViewModels
{
    public class SoftverPrikaziViewModel
    {
        public int ID { get; set; }

        public List<Row> rows;
        public class Row
        {
            public int SoftverID { get; set; }
            public string Naziv { get; set; }
            public string Verzija { get; set; }
            public double cijena { get; set; }
            public string imgfilename { get; set; }
            public string TipSoftvera { get; set; }
            public string Specifikacije { get; set; }
        }
    }
    
}
