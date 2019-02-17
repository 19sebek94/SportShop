using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportShop.Models
{
    public class Cart
    {
        private List<CartLine> CartLines = new List<CartLine>();

        public virtual void AddItem(Product product, int amount)
        {
            CartLine line = CartLines.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if (line == null)
            {
                CartLines.Add(new CartLine
                {
                    Product = product,
                    Amount = amount
                });
            }
            else
                line.Amount += amount;
        }

        public virtual void Remove(Product product) =>
            CartLines.RemoveAll(p => p.Product.ProductID == product.ProductID);

        public virtual void Clear() => CartLines.Clear();

        public virtual decimal ComputeTotalValue() => CartLines.Sum(s => s.Product.Price * s.Amount);

        public virtual IEnumerable<CartLine> Lines => CartLines;


        public class CartLine
        {
            public int CartLineID { get; set; }
            public Product Product { get; set; }
            public int Amount { get; set; }
        }
    }
}
