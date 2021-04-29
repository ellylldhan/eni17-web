using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace m6tp1_dojo.Data
{
    public class m6tp1_dojoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public m6tp1_dojoContext() : base("name=m6tp1_dojoContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<m6tp1_dojo.Models.Samourai>().HasOptional(x => x.Arme);
            modelBuilder.Entity<m6tp1_dojo.Models.Samourai>().HasMany(x => x.ArtsMartiaux).WithMany();
        }

        public System.Data.Entity.DbSet<m6tp1_dojo.Models.Arme> Armes { get; set; }

        public System.Data.Entity.DbSet<m6tp1_dojo.Models.Samourai> Samourais { get; set; }
        public System.Data.Entity.DbSet<m6tp1_dojo.Models.ArtMartial> ArtsMartiaux { get; set; }
    }
}
