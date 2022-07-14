using System;
using System.Collections.Generic;

namespace ITOps.Utilities
{
    public interface IProvideDynamicComponent
    {
        ServiceComponentName ServiceComponentName { get; }
        (Type DynamicComponentType, Dictionary<string, object> Parameters) GetDynamicComponentInfo(Guid key);
    }

    public record ServiceComponentName(string ServiceName, string ComponentName);
}
