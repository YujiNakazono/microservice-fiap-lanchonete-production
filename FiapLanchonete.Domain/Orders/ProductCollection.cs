using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiapLanchonete.Domain.Orders
{
    public sealed class ProductCollection
    {
        private readonly IList<Product> _products;

        public ProductCollection()
        {
            _products = new List<Product>();
        }

        public IReadOnlyCollection<Product> GetProducts()
        {
            IReadOnlyCollection<Product> products = new ReadOnlyCollection<Product>(_products);
            return products;
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

    }
}
