using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.ZaposlenikModul.ViewModels
{
    public class AnalizaPDF
    {
        public string AnalizaID { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum_analize { get; set; }

        public string KlijentID{ get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string ZaposlenikID{ get; set; }
        public string ImeZaposlenika { get; set; }
        public string PrezimeZaposlenika { get; set; }

        public string Softver { get; set; }
        public string SoftverID { get; set; }
    }
}
