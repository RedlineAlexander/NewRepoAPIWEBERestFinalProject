using Microsoft.AspNetCore.Mvc;
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


    }
}
