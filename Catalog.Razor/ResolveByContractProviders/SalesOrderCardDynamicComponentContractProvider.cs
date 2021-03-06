using Branding.DynamicComponents;
using Branding.DynamicComponents.ResolveByContract;
using System;
using System.Collections.Generic;

namespace Catalog.Razor.ResolveByContractProviders
{
    public class SalesOrderCardDynamicComponentContractProvider : DynamicComponentPlacementProvider
    {
        public override string ServiceName => "Catalog";

        protected override ServiceComponentPlacementContract PlaceHolderContract { get; set; } = new ServiceComponentPlacementContract(
            new ServicePlacementName("Sales", "OrderCard"),
            new ServiceDynamicComponentParameterRequirements(
                new Dictionary<string, Type> { { "OrderId", typeof(Guid) } }));

        public override ServiceDynamicComponentContract GetDynamicComponentInfo(Guid? key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key), $"Component {nameof(Order)} requires a key to assign to an OrderId property.");

            return new ServiceDynamicComponentContract(
                typeof(Order),
                new Dictionary<string, object>
                {
                    { "OrderId", key }
                }
            );
        }
    }
}
