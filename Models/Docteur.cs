using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace izySick.Models
{
     public class Docteur : Employe
    {
        //[Key]
        public int DocteurId { get; set; }//primarykey
        public string? Specialisation { get; set; }
        public ICollection<Patient>? Patients { get; set; }//plusieurs
    }
}
