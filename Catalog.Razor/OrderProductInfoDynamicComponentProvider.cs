using Branding.DynamicComponents;
using System;
using System.Collections.Generic;

namespace Catalog.Razor
{
    public class OrderProductInfoDynamicComponentProvider : IProvideDynamicComponent
    {
        public ServiceComponentName ServiceComponentName => new("Catalog", "OrderProductInfo");

        public ServiceDynamicComponentContract GetDynamicComponentInfo(Guid? key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), $"Component {nameof(OrderProductInfo)} requires a key to assign to an OrderId property.");
            return new ServiceDynamicComponentContract(
                typeof(OrderProductInfo),
                new Dictionary<string, object>
                {
                    { "OrderId", key }
                }
            );
        }
    }
}
