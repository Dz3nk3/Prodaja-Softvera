using System;
using System.Collections.Generic;
using System.Text;

namespace Prodaja_Softvera_ver3.Data.EntityModels
{
    public class Kod
    {
        public int ID { get; set; }
        public int kod { get; set; }
        public bool IsValid { get; set; }
        public DateTime VrijemeSlanja { get; set; }

    }
}
