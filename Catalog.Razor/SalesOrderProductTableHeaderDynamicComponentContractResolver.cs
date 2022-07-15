using Branding.DynamicComponents;
using Branding.DynamicComponents.ResolveByPlacementContract;
using System;
using System.Collections.Generic;

namespace Catalog.Razor
{
    public class SalesOrderProductTableHeaderDynamicComponentContractResolver : DynamicComponentPlacementResolver
    {
        protected override ServiceComponentPlacementContract PlaceHolderContract { get; set; } = new ServiceComponentPlacementContract(
            new ServicePlacementName("Sales", "OrderProductTableHeader"),
            "Catalog",
            new ServiceDynamicComponentParameterRequirements(new Dictionary<string, Type>()));

        public override ServiceDynamicComponentContract GetDynamicComponentInfo(Guid? key)
        {
            return new ServiceDynamicComponentContract(
                typeof(OrderProductInfoTableHeader),
                new Dictionary<string, object>()
            );
        }
    }
}
