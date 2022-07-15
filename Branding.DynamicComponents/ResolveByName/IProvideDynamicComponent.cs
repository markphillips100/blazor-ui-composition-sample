using System;
using System.Collections.Generic;

namespace Branding.DynamicComponents.ResolveByName
{
    public interface IProvideDynamicComponent
    {
        ServiceComponentName ServiceComponentName { get; }
        ServiceDynamicComponentContract GetDynamicComponentInfo(Guid? key);
    }
}
