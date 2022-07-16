using Branding.DynamicComponents;
using Branding.DynamicComponents.ResolveByName;
using System;
using System.Collections.Generic;

namespace Catalog.Razor.ResolveByNameProviders
{
    public class OrderTableHeaderDynamicComponentProvider : IProvideDynamicComponent
    {
        public ServiceComponentName ServiceComponentName => new("Catalog", "OrderTableHeader");

        public ServiceDynamicComponentContract GetDynamicComponentInfo(Guid? key)
        {
            return new ServiceDynamicComponentContract(
                typeof(OrderTableHeader),
                new Dictionary<string, object>()
            );
        }
    }
}
