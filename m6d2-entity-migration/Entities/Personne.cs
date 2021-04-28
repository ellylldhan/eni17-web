using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace m6d2_entity_migration.Entities
{
    public class Personne
    {
        public int Id { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public Adresse Adresse { get; set; }

        public override string ToString()
        {
            return $"Id {Id}, Prenom {Prenom}, Nom {Nom}\nAdresse {Adresse?.Numero}, {Adresse?.Nom} (id {Adresse?.Id})\n";
        }
    }
}
 