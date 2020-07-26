using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewRepoAPIWEBERestFinalProject.Models.Repositories
{
    public class SqlOrdersRepository : IOrdersRepository
    {
        private NewRepoAPIWEBRestFinalProjectContext _context { get; set; }
        public SqlOrdersRepository(NewRepoAPIWEBRestFinalProjectContext context)
        {
            _context = context;
        }

        public void CreateOrder(Orders order)
        {
            _context.Orders.Add(order);
           // throw new NotImplementedException();
        }

        public void DeleteOrder(int orderId)
        {
            var order = _context.Orders.SingleOrDefault(order => order.BookingId == orderId);

            try
            {
                _context.Orders.Remove(order);
            }
            catch
            {
                throw new ArgumentNullException($"There is no order or booking with Id = {orderId}");
            }
            finally
            {
                _context.SaveChanges();
            }
           // throw new NotImplementedException();
        }

        public IEnumerable<Orders> GetAllOrders()
        {
            return _context.Orders;

          // throw new NotImplementedException();
        }

        public Orders GetOrder(int orderId)
        {
            return _context.Orders.SingleOrDefault(order => order.BookingId == orderId);
            //throw new NotImplementedException();
        }

        public void ModifyOrder(int orderId, Orders order)
        {

            var orderToModify = _context.Orders.SingleOrDefault(order => order.BookingId == orderId);

            if(orderToModify == null)
            {
                return;
            }

            orderToModify.BookingDate = order.BookingDate;
            orderToModify.BookingPaymentStatusRef = order.BookingPaymentStatusRef;


            _context.SaveChanges();


           // throw new NotImplementedException();
        }
    }
}
