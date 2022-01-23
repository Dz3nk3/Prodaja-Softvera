using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Data.EntityModels
{
    public class TipZaposlenika
    {
        public int TipZaposlenikaID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
    }
}
