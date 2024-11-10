using FiapLanchonete.Domain.Interfaces;
using FiapLanchonete.Domain.Shared;
using FiapLanchonete.Domain.ValueObjects;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;

namespace FiapLanchonete.Domain.Orders
{
    public sealed class Order : IEntity
    {
        public Guid Id { get; private set; }
        public OrderStatus Status { get; private set; }
        public DateTime CreatedAt { get; set; }
        public IReadOnlyCollection<Product> Products
        {
            get
            {
                IReadOnlyCollection<Product> readOnly = _products.GetProducts();
                return readOnly;
            }
        }

        private ProductCollection _products;
        public Order(OrderStatus status, DateTime createdAt)
        {
            Id = Guid.NewGuid();
            Status = status;
            CreatedAt = createdAt;
            _products = new ProductCollection();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }
        private Order()
        {
        }
        public static Order Load(Guid id, OrderStatus orderStatus, DateTime createdAt, ProductCollection products)
        {
            Order order = new Order();
            order.Id = id;
            order.Status = orderStatus;
            order.CreatedAt = createdAt;
            order._products = products;
            return order;
        }

        public void UpdateStatus(OrderStatus status)
        {
            Status = status;
        }
    }
}