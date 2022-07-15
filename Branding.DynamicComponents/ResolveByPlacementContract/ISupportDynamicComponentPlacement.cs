namespace Branding.DynamicComponents.ResolveByPlacementContract
{
    public interface IProvideDynamicComponentPlacement
    {
        bool SupportsPlaceholderContract(ServiceComponentPlacementContract contract);
        ServiceDynamicComponentContract GetDynamicComponentInfo(Guid? key);
    }
}
