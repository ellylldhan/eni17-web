using m6d2_entity_migration.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6d2_entity_migration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new MyDbContext())
            {
                // Eviter les doublons
                if (db.Personnes.Count() > 0)
                {

                    // Ajout de plusieurs personnes
                    for (int i = 0; i < 20; i++)
                    {
                        db.Personnes.Add(new Entities.Personne() { Nom = "n" + i, Prenom = "p" + i });
                    }
                }

                // Eviter les doublons
                if (db.Adresses.Count() > 0)
                {
                    // Ajout de plusieurs Adresses
                    for (int i = 0; i < 8; i++)
                    {
                        db.Adresses.Add(new Entities.Adresse() { Nom = "adr" + i, Numero = i });
                    }

                    // Flush
                    db.SaveChanges();
                }
            }

            // Recuperer une personne et lui affilier une adresse
            using (var db = new MyDbContext())
            {
                db.Personnes.FirstOrDefault(x => x.Id == 1).Adresse = db.Adresses.FirstOrDefault(x => x.Id == 1);
                db.Personnes.FirstOrDefault(x => x.Id == 2).Adresse = db.Adresses.FirstOrDefault(x => x.Id == 2);
                db.SaveChanges();
            }

            // Recuperer des personnes puis les afficher dans la console
            using (var db = new MyDbContext())
            {
                var personnes = db.Personnes.Where(x => x.Id < 3).ToList();
                foreach (var item in personnes)
                {
                    Console.WriteLine(item.ToString());
                }
            }

            // Lit la ligne de caractères suivante du flux d'entrée standard.
            Console.ReadLine();
        }
    }
}
