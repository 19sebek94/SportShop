using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product{Name = "Piłka nożna", Price = 25},
            new Product{Name = "Rakieta tenisowa", Price = 86},
            new Product{Name = "Getry", Price = 14},
            new Product{Name = "Ochraniacze", Price = 56},
            new Product{Name = "Hulajnoga", Price = 130},
        }.AsQueryable();
    }
}
