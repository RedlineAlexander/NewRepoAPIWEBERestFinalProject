using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewRepoAPIWEBERestFinalProject.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewRepoAPIWEBERestFinalProject.Models;

namespace NewRepoAPIWEBERestFinalProject.Controllers
{
    public class ServicesControllers : Controller
    {

        private IServicesRepository _repository { get; set; }


        public ServicesControllers(IServicesRepository repository)
        {
            _repository = repository;
        }
        [AllowAnonymous]
        public IActionResult Index(List<int> servicesIds)
        {
            var services = servicesIds?.Any() != true ? _repository.GetAllServices() : _repository.GetAllServices().Where(x => servicesIds.Contains(x.ServiceID));
            return View(services.ToList());

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(Services services)
        {
            _repository.CreateService(services);
            return View();
        }

    }
}
