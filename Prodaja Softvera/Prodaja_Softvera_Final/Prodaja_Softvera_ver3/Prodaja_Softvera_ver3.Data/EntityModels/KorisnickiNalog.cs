using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Data.EntityModels
{
    public class KorisnickiNalog
    {
        public int ID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }

        public string TipKorisnickogNaloga { get; set; }
    }
}
