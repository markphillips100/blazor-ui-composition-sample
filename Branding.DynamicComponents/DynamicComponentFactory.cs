using System;
using System.Collections.Generic;
using System.Linq;

namespace Branding.DynamicComponents
{
    public class DynamicComponentFactory
    {
        private readonly IEnumerable<IProvideDynamicComponent> _dynamicComponentProviders;

        public DynamicComponentFactory(IEnumerable<IProvideDynamicComponent> dynamicComponentProviders)
        {
            _dynamicComponentProviders = dynamicComponentProviders;
        }

        public ServiceDynamicComponentContract? GetDynamicComponentInfo(ServiceComponentName serviceComponentName, Guid? key)
        {
            var provider = _dynamicComponentProviders.SingleOrDefault(x => x.ServiceComponentName == serviceComponentName);
            if (provider == null)
            {
                return null;
            }

            return provider.GetDynamicComponentInfo(key);
        }
    }
}
