using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.ViewModels
{
    public class ZaposlenikPrikaziVM
    {
        public List<ZaposlenikPrikaziViewModel> podaciZaHtmlTabelu;
    }
    public class ZaposlenikPrikaziViewModel
    {
        public int ZaposlenikID { get; set; }
        public string Naziv { get; set; }
        public string Email { get; set; }
        public string Kontakt_br { get; set; }
        public string Datum_rodjenja { get; set; }
        public string Spol { get; set; }
        public string Grad { get; set; }
        public string Fakultet { get; set; }
        public string TipZaposlenika { get; set; }
        public int BrojSoftvera { get; set; }
    }
}
