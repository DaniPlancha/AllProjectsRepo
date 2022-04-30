using System;
using System.Collections.Generic;

#nullable disable

namespace OnlineStore.DB
{
    public partial class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string BuyerName { get; set; }
        public string Adress { get; set; }
        public DateTime Date { get; set; }

        public virtual Product Product { get; set; }
    }
}
