using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineStore.DB
{
    public partial class Product
    {
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int ColorId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

        public virtual Category Category { get; set; }
        public virtual Color Color { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
