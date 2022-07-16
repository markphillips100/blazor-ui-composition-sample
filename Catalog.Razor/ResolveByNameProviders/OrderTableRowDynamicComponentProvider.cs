using Branding.DynamicComponents;
using Branding.DynamicComponents.ResolveByName;
using System;
using System.Collections.Generic;

namespace Catalog.Razor.ResolveByNameProviders
{
    public class OrderTableRowDynamicComponentProvider : IProvideDynamicComponent
    {
        public ServiceComponentName ServiceComponentName => new("Catalog", "OrderTableRow");

        public ServiceDynamicComponentContract GetDynamicComponentInfo(Guid? key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), $"Component {nameof(OrderTableRow)} requires a key to assign to an OrderId property.");
            return new ServiceDynamicComponentContract(
                typeof(OrderTableRow),
                new Dictionary<string, object>
                {
                    { "OrderId", key }
                }
            );
        }
    }
}
