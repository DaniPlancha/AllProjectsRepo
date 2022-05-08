using Microsoft.EntityFrameworkCore;
using OnlineStore.DB;
using OnlineStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.MVC.Services
{
    public class ProductService
    {
        private readonly OnlineStoreContext _context;
        public ProductService()
        {
            _context = new OnlineStoreContext();
        }
        internal ProductModel Get(int id)
        {
            var product = _context.Products.Include(p => p.Color).Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (product == null) return null;
            return new ProductModel(product.Id, product.Category.Name, product.Color.Name, product.Name, product.Price, product.Description, product.CategoryId);
        }
        internal void Buy(int id)
        {
            _context.Orders.Add(new Order { ProductId = id, BuyerName = "Anonymous", Adress = "Anonymous", Date = DateTime.Now });
            _context.SaveChanges();
        }
    }
}
