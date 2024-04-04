using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace izySick.Models
{
    public class Receptionniste : Employe
    {
        public int ReceptionnisteId { get; set; } //primary key
    }
}



