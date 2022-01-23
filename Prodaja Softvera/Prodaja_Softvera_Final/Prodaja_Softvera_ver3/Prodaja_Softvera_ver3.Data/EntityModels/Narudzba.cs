using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Data.EntityModels
{
    public class Narudzba
    {
        public int NarudzbaID { get; set; }
        public DateTime Datum_narudzbe { get; set; }

        public Klijent Klijent { get; set; }
        public int KlijentID { get; set; }


        public Racun Racun { get; set; }
        public int? RacunID { get; set; }
    }
}
