using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace izySick.Models
{
    public class Medicaments
    {
        //[Key]
        public  int MedicamentsId { get; set; } //primary key
        //public int Id;
        public string NomMedicament { get; set; }
        public int? NbEnStock { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public int? Prix { get; set; }
        public ICollection<MedicamentVendu>? MedVendu { get; set; }//plusieurs
        //public Medicaments(string nom,int nb,string type,string descri,int prix)
        //{
        //    this.Id = IdMedic++;
        //    this.NomMedicament = nom;
        //    this.NbEnStock = nb;
        //    this.Type = type;
        //    this.Description = descri;
        //    this.Prix = prix;
        //}
    }
}
