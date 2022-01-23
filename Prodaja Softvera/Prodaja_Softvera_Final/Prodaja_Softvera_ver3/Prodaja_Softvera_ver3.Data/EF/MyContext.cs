using Microsoft.EntityFrameworkCore;
using Prodaja_Softvera_ver3.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace Prodaja_Softvera_ver3.Data.EF
{
    public class MyContext : DbContext
    {

        public MyContext(DbContextOptions<MyContext> options) 
            : base(options) 
        {
        }
        public DbSet<Analiza> Analiza { get; set; }
        public DbSet<Drzava> Drzava { get; set; }
        public DbSet<Fakultet> Fakultet { get; set; }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Kartica> Kartica { get; set; }
        public DbSet<Klijent> Klijent { get; set; }
        public DbSet<KorisnickiNalog> KorisnickiNalog { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<Ocjena> Ocjena { get; set; }
        public DbSet<Racun> Racun { get; set; }
        public DbSet<Softver> Softver { get; set; }
        public DbSet<SoftverNarudzba> SoftverNarudzba { get; set; }
        public DbSet<Specifikacije> Specifikacije { get; set; }
        public DbSet<TipSoftvera> TipSoftvera { get; set; }
        public DbSet<TipZaposlenika> TipZaposlenika { get; set; }
        public DbSet<Zaposlenik> Zaposlenik { get; set; }
        public DbSet<AutorizacijskiToken> AutorizacijskiToken { get; set; }
        public DbSet<TabelaGreska> TabelaGreska { get; set; }

        public DbSet<Kod> Kod { get; set; }
    }

}