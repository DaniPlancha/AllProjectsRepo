using Microsoft.EntityFrameworkCore;
using OnlineStore.DB;
using OnlineStore.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.MVC.Services
{
    public class CategoryService
    {
        private readonly OnlineStoreContext _context;
        public CategoryService()
        {
            _context = new OnlineStoreContext();
        }
        internal CategoryModel Get(int id)
        {
            var category = _context.Categories.Include(c => c.Products).ThenInclude(p => p.Color).FirstOrDefault(c => c.Id == id);
            if (category == null) return null;
            return new CategoryModel(category.Id, category.Name, category.Products.Select(p => new CategoryProductModel(p.Id, p.Color.Name, p.Name, p.Price)));
        }
        internal IEnumerable<Category> GetAll()
        {
            return _context.Categories.Include(c => c.Products);
        }
    }
}
