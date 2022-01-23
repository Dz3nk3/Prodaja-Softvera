using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Data.EntityModels
{
    public class Kartica
    {
        public int KarticaID { get; set; }

        public string BrojKartice { get; set; }
        public double Iznos { get; set; }

    }
}
