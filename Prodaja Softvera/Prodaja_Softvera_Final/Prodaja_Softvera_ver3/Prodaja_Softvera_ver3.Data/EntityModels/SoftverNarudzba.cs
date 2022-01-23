using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Data.EntityModels
{
    public class SoftverNarudzba
    {
        public int SoftverNarudzbaID { get; set; }
        public DateTime Datum { get; set; }

        public string NazivSoftvera { get; set; }
        public double CijenaSoftvera { get; set; }
        public Softver Softver { get; set; }
        public int SoftverID { get; set; }

        public Narudzba Narudzba { get; set; }
        public int NarudzbaID { get; set; }

        public int Ocjena { get; set; }
        public string Komentar { get; set; }

    }
}
