namespace Branding.DynamicComponents.ResolveByContract
{
    public abstract class DynamicComponentPlacementProvider : IProvideDynamicComponentPlacement
    {
        public abstract string ServiceName { get; }

        protected abstract ServiceComponentPlacementContract PlaceHolderContract { get; set; }

        public abstract ServiceDynamicComponentContract GetDynamicComponentInfo(Guid? key);

        public bool SupportsPlaceholderContract(ServiceComponentPlacementContract contract)
        {
            return
                contract.ServicePlaceHolderName == PlaceHolderContract.ServicePlaceHolderName &&
                contract.ComponentParameterRequirements.ParametersSupported(PlaceHolderContract.ComponentParameterRequirements);
        }
    }
}
