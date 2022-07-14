using ITOps.Utilities;
using System;
using System.Collections.Generic;

namespace Catalog.Razor
{
    public class OrderProductInfoDynamicComponentProvider : IProvideDynamicComponent
    {
        public ServiceComponentName ServiceComponentName => new("Catalog", "OrderProductInfo");

        public (Type, Dictionary<string, object>) GetDynamicComponentInfo(Guid key)
        {
            return (
                typeof(OrderProductInfo),
                new Dictionary<string, object>
                {
                    { "OrderId", key }
                }
            );
        }
    }
}
