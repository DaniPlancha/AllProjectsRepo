using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.MVC.Models
{
    public record CategoryProductModel(int Id, string ColorName, string Name, double Price);
}
