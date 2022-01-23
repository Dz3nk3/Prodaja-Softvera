using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Data.EntityModels
{
    public class Analiza
    {
        public int AnalizaID { get; set; }
        public string Naziv { get; set; }
        public DateTime Datum_analize { get; set; }

        public Klijent Klijent { get; set; }
        public int KlijentID { get; set; }

        public Zaposlenik Zaposlenik { get; set; }
        public int ZaposlenikID { get; set; }

        public Softver Softver { get; set; }
        public int SoftverID { get; set; }
    }
}
