namespace Branding.DynamicComponents
{
    public record ServiceDynamicComponentContract(Type DynamicComponentType, Dictionary<string, object> Parameters);
}
