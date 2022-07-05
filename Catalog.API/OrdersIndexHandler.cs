using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.API.Events;
using ServiceComposer.AspNetCore;
using Services.Data.Sample;
using Catalog.API.Model;

namespace Catalog.API
{
    public class OrdersIndexHandler : ICompositionEventsSubscriber
    {
        private static readonly List<OrderViewModel> _orders = new()
        {
            new OrderViewModel { ProductId = SampleData.ProductId1, Name = "SKU123" },
            new OrderViewModel { ProductId = SampleData.ProductId2, Name = "SKU456" }
        };

        [HttpGet("api/orders")]
        public void Subscribe(ICompositionEventsPublisher publisher)
        {
            publisher.Subscribe<OrdersIndexRequested>((@event, request) =>
            {
                request.GetComposedResponseModel().catalog = new OrdersIndexViewModel { Orders = _orders.ToArray() };

                return Task.CompletedTask;
            });
        }
    }
}