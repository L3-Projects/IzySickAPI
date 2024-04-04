using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izySick.Models
{
    public class Personne
    {
        public string Nom { get;  set; }
        public string Prenom { get;  set; }
        public int? Age { get;  set; }
        public int? Sexe { get;  set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
    }
}
