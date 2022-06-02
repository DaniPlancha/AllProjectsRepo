namespace OnlineStore.MVC.Models
{
    public record ProductModel(int Id, string CategoryName, string ColorName, string Name, double Price, string Description, int CategoryId);
}
