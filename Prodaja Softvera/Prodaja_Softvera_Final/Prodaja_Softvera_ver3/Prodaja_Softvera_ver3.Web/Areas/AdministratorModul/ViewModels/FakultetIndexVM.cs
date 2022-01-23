using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.Areas.AdministratorModul.ViewModels
{
    public class FakultetIndexVM
    {
        public int ID { get; set; }
        public List<Row> row{ get; set; }
        public class Row
        {
            public int FakultetID { get; set; }
            public string Naziv { get; set; }
            public string Univerzitet { get; set; }
        }
    }
}
