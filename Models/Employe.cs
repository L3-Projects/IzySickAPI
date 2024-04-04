using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izySick.Models
{
    public class Employe : Personne
    {
        public string Mdp { get; set; }
        public string? Poste { get; set; }
        public byte[]? Image { get; set; }
    }
}


