using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewRepoAPIWEBERestFinalProject.Models.Repositories
{
    public class SqlPatientsRepository : IPatientsRepository
    {

        private NewRepoAPIWEBRestFinalProjectContext _context { get; set; }
        public SqlPatientsRepository (NewRepoAPIWEBRestFinalProjectContext context)
        {
            _context = context;
        }

        public void CreatePatient(Patients patient)
        {

            _context.Patients.Add(patient);
            _context.SaveChanges();
           // throw new NotImplementedException();
        }

        public void DeletePatient(int patientId)
        {

            var patient = _context.Patients.SingleOrDefault(patient => patient.PatientID == patientId);
            try
            {
                _context.Patients.Remove(patient);

            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException($"There is no patient with Id = {patientId}");
            }
            finally
            {
                _context.SaveChanges();
            }
          //  throw new NotImplementedException();
        }

        public IEnumerable<Patients> GetAllPatients()
        {
            return _context.Patients;
         //   throw new NotImplementedException();
        }

        public Patients GetPatient(int patientId)
        {
            return _context.Patients.SingleOrDefault(patient => patient.PatientID == patientId);
          //  throw new NotImplementedException();
        }

        public void ModifyPatient(int patientId, Patients patient)
        {
            var patientToModify = _context.Patients.SingleOrDefault(patient => patient.PatientID == patientId);

            if(patientToModify == null)
            {
                return;
            }
            //
            patientToModify.PatientName = patient.PatientName;
            patientToModify.PatientBirthDate = patient.PatientBirthDate;
            patientToModify.PatientSexRef = patient.PatientSexRef;
            patientToModify.PatientPhone = patient.PatientPhone;

            _context.SaveChanges();
           // throw new NotImplementedException();
        }
    }
}
