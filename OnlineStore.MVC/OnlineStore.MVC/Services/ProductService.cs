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
        private OnlineStoreContext _context;
        public ProductService()
        {
            _context = new OnlineStoreContext();
        }
        internal ProductModel Get(int id)
        {
            var prod = _context.Products.Include(p => p.Color).Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            if (prod == null) return null;
            return new ProductModel(prod.Id, prod.Category.Name, prod.Color.Name, prod.Name, prod.Price, prod.Description, prod.CategoryId);
        }
    }
}
