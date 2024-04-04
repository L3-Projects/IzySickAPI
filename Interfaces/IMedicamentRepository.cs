using izySick.Models;

namespace IzySickAPI.Interfaces
{
    public interface IMedicamentRepository
    {
        ICollection<Medicaments> GetMedicaments();
        Medicaments GetMedicament(int id);
        bool MedicamentExists( int  id );
        bool CreateMedicament(Medicaments medicament);
        bool UpdateMedicament(Medicaments medicament);
        bool DeleteMedicament(Medicaments medicament);
        bool Save();
    }
}
