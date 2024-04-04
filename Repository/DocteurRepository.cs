using izySick.Models;
using IzySickAPI.Data;
using IzySickAPI.Interfaces;

namespace IzySickAPI.Repository
{
    public class DocteurRepository : IDocteurRepository
    {
        private readonly DataContext _context;

        public DocteurRepository(DataContext context)
        {
            _context = context;
        }

        public bool DocteurExists(int DocId)
        {
            return _context.Docteurss.Any(p=>p.DocteurId==DocId);
        }

        public Docteur GetDocteur(int id)
        {
            return _context.Docteurss.Where(d => d.DocteurId == id).FirstOrDefault(); // FirstOrDefault(retourne un seul)/ToList(retourne plusieurs)
        }

        public Docteur GetDocteur(string name)
        {
            return _context.Docteurss.Where(p => p.Nom == name).FirstOrDefault();
        }

        public int GetNombrePatients(int DocId)
        {
            var patients = _context.Patientss.Where(p => p.DocteurId == DocId);
            if (patients.Count() == 0) {
                return 0;
            }
            return patients.Count();
        }

        public ICollection<Docteur> GetDocteurs()
        {
            return _context.Docteurss.OrderBy(d=>d.DocteurId).ToList();
        }

        public ICollection<Patient> GetPatientOfDocteur(int DocId)
        {
            return _context.Patientss.Where(p=>p.DocteurId == DocId).ToList();
        }

        public bool CreateDocteur(Docteur docteur)
        {
            _context.Add(docteur);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateDocteur(Docteur docteur)
        {
            _context.Update(docteur);
            return Save();  
        }

        public bool DeleteDocteur(Docteur docteur)
        {
            _context.Remove(docteur);
            return Save();
        }
    }
}
