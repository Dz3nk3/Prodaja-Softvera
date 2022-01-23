using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.ViewModels
{
    public class AnalizaPrikaziVM
    {
        public List<AnalizaPrikaziViewModel> podaciZaHtmlTabelu;
    }
    public class AnalizaPrikaziViewModel
    {
       
        public int AnalizaID { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum_analize { get; set; }
        public string Klijent { get; set; }
        public string Zaposlenik { get; set; }
        public string Softver { get; set; }
    }
}
