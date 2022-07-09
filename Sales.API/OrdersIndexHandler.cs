using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sales.API.Events;
using Sales.API.Model;
using ServiceComposer.AspNetCore;
using Services.Data.Sample;

namespace Sales.API
{
    public class OrdersIndexHandler : ICompositionRequestsHandler
    {
        private static readonly List<OrderViewModel> _orders = new()
        {
            new OrderViewModel { OrderId = SampleData.OrderId1, Price = 100, ProductId = SampleData.ProductId1 },
            new OrderViewModel { OrderId = SampleData.OrderId2, Price = 200, ProductId = SampleData.ProductId2 }
        };
    
        [HttpGet("api/orders")]
        public async Task Handle(HttpRequest request)
        {
            var vm = request.GetComposedResponseModel();
            vm.sales = new OrdersIndexViewModel { OrdersMap = _orders.ToDictionary(x => x.OrderId, x => x) };

            await request
                .GetCompositionContext()
                .RaiseEvent(new OrdersIndexRequested
                {
                    ProductIds = _orders.Select(x => x.ProductId).ToArray()
                });
        }
    }
}