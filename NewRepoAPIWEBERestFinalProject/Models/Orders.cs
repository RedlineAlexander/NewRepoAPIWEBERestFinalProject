using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewRepoAPIWEBERestFinalProject.Models
{
    public class Orders
    {

        public int BookingId { get; set; }
        public List<Services> Services { get; set; }

        public List<Patients> Patients { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingPaymentStatusRef { get; set; }
    }
}
