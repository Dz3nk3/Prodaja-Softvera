using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Data.EntityModels
{
    public class Grad
    {
        public int GradID { get; set; }
        public string Naziv { get; set; }
        public Drzava Drzava { get; set; }
        public int DrzavaID { get; set; }
    }
}
