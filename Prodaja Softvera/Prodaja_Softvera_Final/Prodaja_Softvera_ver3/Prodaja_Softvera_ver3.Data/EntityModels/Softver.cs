using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Data.EntityModels
{
    public class Softver
    {
        public int SoftverID { get; set; }
        public string Naziv { get; set; }
        public string Verzija { get; set; }
        public double Cijena { get; set; }
        public string imgurl { get; set; }

        public TipSoftvera TipSoftvera { get; set; }
        public int TipSoftveraID { get; set; }

        public Specifikacije Specifikacije { get; set; }
        public int SpecifikacijeID { get; set; }
    }
}
