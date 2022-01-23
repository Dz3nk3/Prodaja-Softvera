using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.KlijentModul.ViewModels
{
    public class KupiVM
    {
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        public int Cijena{ get; set; }
        public int NacinPlacanjaID { get; set; }
        public List<SelectListItem> NacinPlacanja { get; set; }
        public int DostavaID { get; set; }
        public List<SelectListItem> Dostava { get; set; }

        public int Ocjena { get; set; }

    }
}
