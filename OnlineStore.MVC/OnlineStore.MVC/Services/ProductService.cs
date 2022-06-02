using Microsoft.EntityFrameworkCore;
using OnlineStore.DB;
using OnlineStore.MVC.Models;
using System;
using System.Linq;

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
        public void Create(ProductModel product)
        {
            var categoryId = _context.Categories.FirstOrDefault(c => c.Name == product.CategoryName).Id;
            var colorId = _context.Colors.FirstOrDefault(c => c.Name == product.ColorName).Id;
            _context.Products.Add(new Product { CategoryId = categoryId, ColorId = colorId, Name = product.Name, Price = product.Price, Description = product.Description });
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            _context.Orders.Where(o => o.ProductId == id).ForEachAsync(o => _context.Orders.Remove(o));
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
