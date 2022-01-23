using Prodaja_Softvera_ver3.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodaja_Softvera_ver3.Web.ViewModels
{
    public class ProductModel
    {
        public int SoftverNarudzbaID { get; set; }
        public string Datum { get; set; }

        public int SoftverID { get; set; }


        public int NarudzbaID { get; set; }


        public int Kolicina { get; set; }


        public List<Softver> _product { get; set; }
        public List<Softver> findAll()
        {
            _product = new List<Softver> { new Softver()
            {
                SoftverID = 1, Naziv = "Mp3",Cijena = 15,Verzija = "1.2.3",SpecifikacijeID = 1, TipSoftveraID = 1
            },
             new Softver()
            {
                SoftverID = 2, Naziv = "Visual studio",Cijena = 15,Verzija = "1.2.3",SpecifikacijeID = 1, TipSoftveraID = 1
            },
              new Softver()
            {
                SoftverID = 3, Naziv = "Fraps",Cijena = 15,Verzija = "1.2.3",SpecifikacijeID = 2, TipSoftveraID = 1
            },
               new Softver()
            {
                SoftverID = 4, Naziv = "Age of empire 4",Cijena = 15,Verzija = "1.2.3",SpecifikacijeID = 3, TipSoftveraID = 1
            },
                new Softver()
            {
                SoftverID = 5, Naziv = "Age of empire 5",Cijena = 15,Verzija = "1.2.3",SpecifikacijeID = 3, TipSoftveraID = 1
            }

            };

            return _product;
        }

        public Softver find(int id)
        {
            List<Softver> products = findAll();
            var prod = products.Where(a => a.SoftverID == id).FirstOrDefault();

            return prod;
        }
    }
}
