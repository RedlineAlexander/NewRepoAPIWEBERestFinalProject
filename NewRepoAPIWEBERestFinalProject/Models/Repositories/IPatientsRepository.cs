using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewRepoAPIWEBERestFinalProject.Models.Repositories
{
   public interface IPatientsRepository
    {
        public IEnumerable<Patients> GetAllPatients();
        public Patients GetPatient(int patientId);
        public void CreatePatient(Patients patient);
        public void ModifyPatient(int patientId, Patients patient);
        public void DeletePatient(int patientId);


    }
}
