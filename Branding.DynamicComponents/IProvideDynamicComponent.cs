using System;
using System.Collections.Generic;

namespace Branding.DynamicComponents
{
    public interface IProvideDynamicComponent
    {
        ServiceComponentName ServiceComponentName { get; }
        ServiceDynamicComponentContract GetDynamicComponentInfo(Guid? key);
    }

    public record ServiceComponentName(string ServiceName, string ComponentName);
    public record ServiceDynamicComponentContract(Type DynamicComponentType, Dictionary<string, object> Parameters);
}
