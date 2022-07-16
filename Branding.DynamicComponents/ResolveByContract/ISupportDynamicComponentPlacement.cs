namespace Branding.DynamicComponents.ResolveByContract
{
    public interface IProvideDynamicComponentPlacement
    {
        string ServiceName { get; }
        bool SupportsPlaceholderContract(ServiceComponentPlacementContract contract);
        ServiceDynamicComponentContract GetDynamicComponentInfo(Guid? key);
    }
}
