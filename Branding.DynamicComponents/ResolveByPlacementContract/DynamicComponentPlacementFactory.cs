namespace Branding.DynamicComponents.ResolveByPlacementContract
{
    public class DynamicComponentPlacementFactory
    {
        private readonly IEnumerable<IProvideDynamicComponentPlacement> _dynamicComponentPlacementProviders;

        public DynamicComponentPlacementFactory(IEnumerable<IProvideDynamicComponentPlacement> dynamicComponentPlacementProviders)
        {
            _dynamicComponentPlacementProviders = dynamicComponentPlacementProviders;
        }

        public ServiceDynamicComponentContract? GetDynamicComponentInfo(ServiceComponentPlacementContract contract, Guid? key)
        {
            var provider = _dynamicComponentPlacementProviders.FirstOrDefault(x => x.SupportsPlaceholderContract(contract));
            if (provider == null)
            {
                return null;
            }

            return provider.GetDynamicComponentInfo(key);
        }
    }
}
