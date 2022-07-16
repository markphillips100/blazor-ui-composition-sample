namespace Branding.DynamicComponents.ResolveByContract
{
    public record ServiceDynamicComponentParameterRequirements(Dictionary<string, Type> Parameters)
    {
        public bool ParametersSupported(ServiceDynamicComponentParameterRequirements parameterRequirements)
        {
            if (parameterRequirements.Parameters.Count != Parameters.Count) return false;

            foreach (var key in parameterRequirements.Parameters.Keys)
            {
                if (!Parameters.ContainsKey(key)) return false;
                if (Parameters[key] != parameterRequirements.Parameters[key]) return false;
            }

            return true;
        }
    }
}
