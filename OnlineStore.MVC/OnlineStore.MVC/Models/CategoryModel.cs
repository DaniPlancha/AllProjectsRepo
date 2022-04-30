using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.MVC.Models
{
    public record CategoryModel(int Id, string Name, IEnumerable<CategoryProductModel> Products);
}
