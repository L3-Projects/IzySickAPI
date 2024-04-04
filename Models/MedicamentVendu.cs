using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izySick.Models
{
    public class MedicamentVendu
    {
        //[Key]
        public int MedicamentVenduId { get; set; } //primary key
        //public int Id;
        public int? QuantiteVendu { get; set; }
        //[ForeignKey("Medicaments")]
        public int MedicamentsId { get; set; } //foreignkey
        //public MedicamentVendu(int qte, int id)
        //{
        //    this.QuantiteVendu = qte;
        //    this.IdMedic = id;
        //}

    }
}
