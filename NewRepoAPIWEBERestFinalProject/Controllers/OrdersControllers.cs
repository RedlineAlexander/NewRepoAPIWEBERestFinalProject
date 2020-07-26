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
    public class OrdersControllers : Controller
    {
        private IOrdersRepository _repository { get; set; }

        public OrdersControllers(IOrdersRepository repository)
        {
            _repository = repository;
        }

        [AllowAnonymous]
        public IActionResult Index(List<int> ordersIds)
        {
            var patients = ordersIds?.Any() != true ? _repository.GetAllOrders() : _repository.GetAllOrders().Where(x => ordersIds.Contains(x.BookingId));
            return View(patients.ToList());

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(Orders orders)
        {
            _repository.CreateOrder(orders);
            return View();
        }


    }
}
