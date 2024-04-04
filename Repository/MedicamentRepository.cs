using izySick.Models;
using IzySickAPI.Data;
using IzySickAPI.Interfaces;

namespace IzySickAPI.Repository
{
    public class MedicamentRepository : IMedicamentRepository
    {
        private readonly DataContext _context;

        public MedicamentRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateMedicament(Medicaments medicament)
        {
            _context.Add(medicament);
            return Save();
        }

        public bool DeleteMedicament(Medicaments medicament)
        {
            _context.Remove(medicament);
            return Save();
        }

        public Medicaments GetMedicament(int id)
        {
            return _context.Medicamentss.Where(m=>m.MedicamentsId == id).FirstOrDefault();
        }

        public ICollection<Medicaments> GetMedicaments()
        {
            return _context.Medicamentss.OrderBy(m=>m.MedicamentsId).ToList();
        }

        public bool MedicamentExists(int id)
        {
            return _context.Medicamentss.Any(p => p.MedicamentsId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateMedicament(Medicaments medicament)
        {
            _context.Update(medicament);
            return Save();
        }
    }
}
