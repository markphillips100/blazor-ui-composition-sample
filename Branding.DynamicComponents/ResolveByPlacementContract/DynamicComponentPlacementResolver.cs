namespace Branding.DynamicComponents.ResolveByPlacementContract
{
    public abstract class DynamicComponentPlacementResolver : IProvideDynamicComponentPlacement
    {
        protected abstract ServiceComponentPlacementContract PlaceHolderContract { get; set; }

        public abstract ServiceDynamicComponentContract GetDynamicComponentInfo(Guid? key);

        public bool SupportsPlaceholderContract(ServiceComponentPlacementContract contract)
        {
            return
                contract.ServicePlaceHolderName == PlaceHolderContract.ServicePlaceHolderName &&
                contract.ComponentServiceScope == PlaceHolderContract.ComponentServiceScope &&
                contract.ComponentParameterRequirements.ParametersSupported(PlaceHolderContract.ComponentParameterRequirements);
        }
    }

}
