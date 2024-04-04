using izySick.Models;

namespace IzySickAPI.Interfaces
{
    public interface IDocteurRepository
    {
        ICollection<Docteur> GetDocteurs();
        Docteur GetDocteur(int id);
        Docteur GetDocteur(string name);
        int GetNombrePatients(int DocId);
        ICollection<Patient> GetPatientOfDocteur(int DocId);
        bool DocteurExists(int  DocId);
        bool CreateDocteur(Docteur docteur);
        bool UpdateDocteur(Docteur docteur);
        bool DeleteDocteur(Docteur docteur);
        bool Save();
    }
}
