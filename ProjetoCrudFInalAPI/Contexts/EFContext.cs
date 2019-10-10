using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjetoCrudeFInalAPI.Models;

namespace ProjetoCrudeFInalAPI.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("TrabalhoCrude")
        {
            //Database.SetInitializer<EFContext>
            //       (new AppContextInitializer());
        }

        public DbSet<Personagens> Personagens { get; set; }
        public DbSet<Inventarios> Inventario { get; set; }
        public DbSet<Itens> Itens { get; set; }
    }
    //public class AppContextInitializer : DropCreateDatabaseAlways<EFContext> { }

}