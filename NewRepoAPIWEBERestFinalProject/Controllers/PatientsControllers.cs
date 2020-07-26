using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewRepoAPIWEBERestFinalProject.Models;
using NewRepoAPIWEBERestFinalProject.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewRepoAPIWEBERestFinalProject.Controllers
{
    public class PatientsControllers : Controller
    {
        private IPatientsRepository _repository { get; set; }    


        public PatientsControllers( IPatientsRepository repository)
        {
            _repository = repository;
        }


        [AllowAnonymous]
        public IActionResult Index(List<int> patientsIds)
        {
            var patients = patientsIds?.Any() != true ? _repository.GetAllPatients() : _repository.GetAllPatients().Where(x => patientsIds.Contains(x.PatientID));
            return View(patients.ToList());

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(Patients patients)
        {
            _repository.CreatePatient(patients);
            return View();
        }
       
    }
}
