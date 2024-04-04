using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace izySick.Models
{
    public class Patient : Personne
    {
        //[Key]
        public int PatientId;//primary key
        public byte[]? Image { get; set; }
        public int? Urgence { get;  set; }
        public int? Hospitalise { get;  set; }
        public Docteur? DocteurTraitant { get; set; }
        public string? Batiment { get;  set; }
        public int? Chambre { get;  set; }
        public int? Etage { get;  set; }

        public string? Adresse { get;  set; }

        public string? Maladie { get;  set; }

        public string? Traitement { get;  set; }
        public Medicaments? Medicament { get;  set; }
        public DateTime? DateRdv { get;  set; }
        public DateTime? DateHosp { get;  set; }
        public DateTime? DateSortie { get;  set; }

        public int? Limite { get;  set; } //Limite de visiteur
        public int? Autorisation { get;  set; } //Autorisé à être visité ou pas
        public string? Motif { get;  set; }
        //[ForeignKey("Docteur")]
        public int DocteurId { get; set; } //foreign key


    }
}
