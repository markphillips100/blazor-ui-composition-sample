namespace Sales.API.Model
{
    public class OrderViewModel
    {
        public Guid OrderId { get; set; }
        public int Price { get; set; }
        public Guid ProductId { get; set; }
    }
}