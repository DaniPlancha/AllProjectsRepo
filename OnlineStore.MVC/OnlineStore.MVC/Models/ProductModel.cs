using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.MVC.Models
{
    public record ProductModel(int Id, string CategoryName, string ColorName, string Name, double Price, string Description, int CategoryId);
}
