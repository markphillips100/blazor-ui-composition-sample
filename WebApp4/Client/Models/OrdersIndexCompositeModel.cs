namespace WebApp4.Client.Models
{
    public class OrdersIndexCompositeModel
    {
        public Sales.API.Model.OrdersIndexViewModel? Sales { get; set; }
        public Catalog.API.Model.OrdersIndexViewModel? Catalog { get; set; }
    }
}
