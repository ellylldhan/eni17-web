using m6d1_dbcontext.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6d1_dbcontext
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                // Ajout de plusieurs personnes
                for (int i = 0; i < 20; i++)
                {
                    db.Personnes.Add(new Entities.Personne() { Nom = "n" + i, Prenom = "p" + i });
                }

                // Flush
                db.SaveChanges();
            }
            // Lit la ligne de caractères suivante du flux d'entrée standard.
            Console.ReadLine();
        }
    }
}

