using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Data.EntityModels
{
    public class Ocjena
    {
        public int OcjenaID { get; set; }
        public int ocjena { get; set; }
        public string komentar { get; set; }
    }
}
