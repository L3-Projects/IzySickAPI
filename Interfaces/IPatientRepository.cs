using izySick.Models;

namespace IzySickAPI.Interfaces
{
    public interface IPatientRepository
    {
        ICollection<Patient> GetPatients();
        Patient GetPatient(int id);
        bool CreatePatient(int docteurId, Patient patient);
        bool UpdatePatient(int docteurId, Patient patient);
        bool CreatePatient(Patient patient);
        bool DeletePatient(Patient patient);  
        bool PatientExists(int patientId);
        bool Save();
    }
}
