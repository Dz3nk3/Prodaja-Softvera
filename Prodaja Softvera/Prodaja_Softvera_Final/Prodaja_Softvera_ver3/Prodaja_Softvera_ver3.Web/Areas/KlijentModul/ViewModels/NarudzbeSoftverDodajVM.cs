using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.KlijentModul.ViewModels
{
    public class NarudzbeSoftverDodajVM
    {
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        public int Kolicina { get; set; }
        public int SoftverID { get; set; }
        public int NarudzbaID { get; set; }
        public int OcjenaID { get; set; }

    }
}
