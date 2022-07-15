using Branding.DynamicComponents;
using Branding.DynamicComponents.ResolveByPlacementContract;
using System;
using System.Collections.Generic;

namespace Catalog.Razor
{
    public class SalesOrderProductTableRowDynamicComponentContractResolver : DynamicComponentPlacementResolver
    {
        protected override ServiceComponentPlacementContract PlaceHolderContract { get; set; } = new ServiceComponentPlacementContract(
            new ServicePlacementName("Sales", "OrderProductTableRow"),
            "Catalog",
            new ServiceDynamicComponentParameterRequirements(
                new Dictionary<string, Type> { { "OrderId", typeof(Guid) } }));

        public override ServiceDynamicComponentContract GetDynamicComponentInfo(Guid? key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), $"Component {nameof(OrderProductInfoTableRow)} requires a key to assign to an OrderId property.");

            return new ServiceDynamicComponentContract(
                typeof(OrderProductInfoTableRow),
                new Dictionary<string, object>
                {
                    { "OrderId", key }
                }
            );
        }
    }
}
