using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewRepoAPIWEBERestFinalProject.Models.Repositories
{
    public class SqlServicesRepository : IServicesRepository
    {

        private NewRepoAPIWEBRestFinalProjectContext _context { get; set; }
        public SqlServicesRepository(NewRepoAPIWEBRestFinalProjectContext context)
        {
            _context = context;
        }
        public void CreateService(Services service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            //throw new NotImplementedException();
        }

        public void DeleteService(int serviceId)
        {
            var service = _context.Services.SingleOrDefault(service => service.ServiceID == serviceId);
            try
            {
                _context.Services.Remove(service);
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException($"There is no service with Id = {serviceId}");
            }
            finally
            {
                _context.SaveChanges();
            }
            // throw new NotImplementedException();
        }

        public IEnumerable<Services> GetAllServices()
        {
            return _context.Services;
           // throw new NotImplementedException();
        }

        public Services GetService(int serviceId)
        {
            return _context.Services.SingleOrDefault(service => service.ServiceID == serviceId);
          //  throw new NotImplementedException();
        }

        public void ModifyService(int serviceId, Services service)
        {
            var serviceToModify = _context.Services.SingleOrDefault(service => service.ServiceID == serviceId);

            if (serviceToModify == null)
            {
                return;
            }
          //  serviceToModify.ServiceID = service.ServiceID;
            serviceToModify.ServiceNameLanguage = service.ServiceNameLanguage;
            serviceToModify.ServiceCode = service.ServiceCode;
            serviceToModify.ServicePriceRate = service.ServicePriceRate;

           // throw new NotImplementedException();
        }
    }
}
