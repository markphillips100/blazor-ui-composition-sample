namespace Catalog.API.Model
{
    public class OrdersIndexViewModel
    {
        public Dictionary<Guid, OrderViewModel>? OrdersMap { get; set; }
    }
}