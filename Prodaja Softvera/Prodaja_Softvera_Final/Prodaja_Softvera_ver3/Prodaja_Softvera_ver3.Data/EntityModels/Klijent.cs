using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Data.EntityModels
{
    public class Klijent
    {
        public int KlijentID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Email { get; set; }
        public string Kontakt_broj { get; set; }
        public string Datum_rodjenja { get; set; }


        public Grad Grad { get; set; }
        public int GradID { get; set; }


        public Kartica Kartica { get; set; }
        public int KarticaID { get; set; }


        [ForeignKey(nameof(KorisnickiNalog))]
        public int? KorisnickiNalogID { get; set; }
        public KorisnickiNalog KorisnickiNalog { get; set; }
    }
}
