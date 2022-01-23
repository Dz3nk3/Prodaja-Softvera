using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.KlijentModul.ViewModels
{
    public class RacunDodajVM
    {
        public int ID { get; set; }

        public string Datum { get; set; }
        public int Kolicina { get; set; }
        public int SoftverID { get; set; }
        public int NarudzbaID { get; set; }
        public int SoftverNarudzbaID { get; set; }


        public int Ocjena { get; set; }
        public string Komentar { get; set; }


    }
}
