using izySick.Models;
using IzySickAPI.Data;
using IzySickAPI.Interfaces;

namespace IzySickAPI.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly DataContext _context;

        public PatientRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreatePatient(Patient patient)
        {
            //Change Tracker
            //add, updating, modifying
            //connected or disconnected
            //EntityState.Added
            //
            _context.Add(patient);
            return Save();
            
        }

        public bool CreatePatient(int docteurId, Patient patient)
        {
            var doc = _context.Docteurss.Where(d=>d.DocteurId == docteurId).FirstOrDefault();
            patient.DocteurTraitant = doc;
            _context.Add(patient);
            return Save();
        }

        public bool DeletePatient(Patient patient)
        {
            _context.Remove(patient);
            return Save();
        }

        public Patient GetPatient(int id)
        {
            return _context.Patientss.Where(p=>p.PatientId==id).FirstOrDefault();
        }

        public ICollection<Patient> GetPatients()
        {
            return _context.Patientss.OrderBy(p=>p.PatientId).ToList();
        }

        public bool PatientExists(int patientId)
        {
            return _context.Patientss.Any(p => p.PatientId == patientId);
        }

        public bool Save()
        {
           var saved = _context.SaveChanges();
            return saved > 0 ? true : false; 
        }

        public bool UpdatePatient(int docteurId, Patient patient)
        {
            patient.PatientId = docteurId;
            _context.Update(patient);
            return Save();  
        }
    }
}
