using m6d1_dbcontext.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6d1_dbcontext.Databases
{
       public class MyDbContext:DbContext
    {
        public DbSet<Personne> Personnes { get; set; }
        public DbSet<Role> Roles { get; set; }


    }
}
