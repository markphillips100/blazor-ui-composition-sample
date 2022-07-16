namespace Branding.DynamicComponents.ResolveByContract
{
    public class DynamicComponentPlacementFactory
    {
        private readonly IEnumerable<IProvideDynamicComponentPlacement> _dynamicComponentPlacementProviders;

        public DynamicComponentPlacementFactory(IEnumerable<IProvideDynamicComponentPlacement> dynamicComponentPlacementProviders)
        {
            _dynamicComponentPlacementProviders = dynamicComponentPlacementProviders;
        }

        public ServiceDynamicComponentContract[] GetDynamicComponentInfoIndex(ServiceComponentPlacementContract contract, string? serviceOrder, Guid? key)
        {
            var serviceOrderList = serviceOrder == null ? new List<string>() : serviceOrder.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();

            return _dynamicComponentPlacementProviders
                .Where(x => (serviceOrderList.Count == 0 || serviceOrderList.Contains(x.ServiceName)) && x.SupportsPlaceholderContract(contract))
                .OrderBy(x => serviceOrderList.IndexOf(x.ServiceName))
                .Select(x => x.GetDynamicComponentInfo(key))
                .ToArray();
        }
    }
}
