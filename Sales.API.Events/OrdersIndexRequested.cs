namespace Sales.API.Events
{
    public class OrdersIndexRequested
    {
        public Guid[]? ProductIds { get; set; }
    }
}