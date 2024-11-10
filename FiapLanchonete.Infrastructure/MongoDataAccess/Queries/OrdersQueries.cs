using FiapLanchonete.Application.Queries;
using FiapLanchonete.Application.Results;
using FiapLanchonete.Domain.Orders;
using FiapLanchonete.Domain.ValueObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapLanchonete.Infrastructure.MongoDataAccess.Queries
{
    public class OrdersQueries : IOrdersQueries
    {
        private readonly Context _context;

        public OrdersQueries(Context context)
        {
            _context = context;
        }

        public async Task<OrderResult> CreateOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public async Task<OrderResult> GetOrder(Guid orderId)
        {
            Entities.Order order = await _context
                .Orders
                .Find(e => e.Id == orderId)
                .SingleOrDefaultAsync();

            ProductCollection productCollection = new ProductCollection();
            productCollection.Add(Domain.Product.Create("Hamburger",1,"Lanche"));

            Order result = Order.Load(orderId, order.Status, order.CreatedAt, productCollection);

            OrderResult orderResult = new OrderResult(result);

            return orderResult;
        }

        public async Task<IEnumerable<Order>> GetOrdersByStatus(OrderStatus orderStatus)
        {
            // Use the filter to find matching documents in the Orders collection
            List<Entities.Order> orders = await _context.Orders.Find(order => order.Status == orderStatus).ToListAsync();

            return orders is null ? throw new NullReferenceException() : (IEnumerable<Order>)orders;
        }
    }
}
