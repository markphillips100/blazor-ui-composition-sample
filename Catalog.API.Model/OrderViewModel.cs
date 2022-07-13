namespace Catalog.API.Model
{
    public class OrderViewModel
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
    }
}