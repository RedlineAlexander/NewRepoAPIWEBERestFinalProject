using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewRepoAPIWEBERestFinalProject.Models
{
    public class Patients
    {

        public int PatientID { get; set; }
        public string PatientName { get; set; }
        public DateTime PatientBirthDate { get; set; }
        public string PatientSexRef { get; set; }
        public string PatientPhone { get; set; }

    }
}
