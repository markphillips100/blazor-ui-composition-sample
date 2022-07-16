using Branding.DynamicComponents;
using Branding.DynamicComponents.ResolveByContract;
using System;
using System.Collections.Generic;

namespace Catalog.Razor.ResolveByContractProviders
{
    public class SalesOrderTableHeaderDynamicComponentContractProvider : DynamicComponentPlacementProvider
    {
        public override string ServiceName => "Catalog";

        protected override ServiceComponentPlacementContract PlaceHolderContract { get; set; } = new ServiceComponentPlacementContract(
            new ServicePlacementName("Sales", "OrderTableHeader"),
            new ServiceDynamicComponentParameterRequirements(new Dictionary<string, Type>()));

        public override ServiceDynamicComponentContract GetDynamicComponentInfo(Guid? key)
        {
            return new ServiceDynamicComponentContract(
                typeof(OrderTableHeader),
                new Dictionary<string, object>()
            );
        }
    }
}
