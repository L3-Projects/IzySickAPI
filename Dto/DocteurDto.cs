using izySick.Models;

namespace IzySickAPI.Dto
{
    public class DocteurDto
    {
        public int DocteurId { get; set; }//primarykey
        public string Mdp { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string? Email { get; set; }
        public string? Telephone { get; set; }
        public ICollection<Patient>? Patients { get; set; }//plusieurs
    }
}
