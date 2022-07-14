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
            new OrderViewModel { OrderId = SampleData.OrderId1, ProductId = SampleData.ProductId1, Name = "SKU123" },
            new OrderViewModel { OrderId = SampleData.OrderId2, ProductId = SampleData.ProductId2, Name = "SKU456" }
        };

        [HttpGet("api/orders")]
        public void Subscribe(ICompositionEventsPublisher publisher)
        {
            publisher.Subscribe<OrdersIndexRequested>((@event, request) =>
            {
                request.GetComposedResponseModel().catalog = new OrdersIndexViewModel
                {
                    OrdersMap = _orders.ToDictionary(x => x.OrderId, x => x)
                };

                return Task.CompletedTask;
            });
        }
    }
}