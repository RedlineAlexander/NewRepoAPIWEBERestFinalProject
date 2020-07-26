using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewRepoAPIWEBERestFinalProject.Models.Repositories
{
    public interface IOrdersRepository
    {
        public IEnumerable<Orders> GetAllOrders();
        public Orders GetOrder(int orderId);
        public void CreateOrder(Orders order);
        public void ModifyOrder(int orderId, Orders order);
        public void DeleteOrder(int orderId);
    }
}
