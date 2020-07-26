using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewRepoAPIWEBERestFinalProject.Models.Repositories
{
    public interface IServicesRepository
    {
        public IEnumerable<Services> GetAllServices();
        public Services GetService(int serviceId);
        public void CreateService(Services service);
        public void ModifyService(int serviceId, Services service);
        public void DeleteService(int serviceId);
    }
}
