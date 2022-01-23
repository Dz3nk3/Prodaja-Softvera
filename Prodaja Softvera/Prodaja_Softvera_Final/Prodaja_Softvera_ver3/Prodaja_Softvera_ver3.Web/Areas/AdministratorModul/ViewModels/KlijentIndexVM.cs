﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.AdministratorModul.ViewModels
{
    public class KlijentIndexVM
    {
        public List<Row> rows;

        public class Row
        {
            public int KlijentID { get; set; }
            public string Naziv { get; set; }
            public string Adresa { get; set; }
            public string Email { get; set; }
            public string Kontakt_broj { get; set; }
            public string Datum_rodjenja { get; set; }
            public string Grad { get; set; }
            public string BrojKartice { get; set; }
            public int BrojSoftvera { get; set; }
        }
    }
}
