using AgentMesh.Models;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class TechnicalSpecificationParameter : BaseEWParameterConfiguration<string>
    {
        public override string Name => "Technical specification";
    }
}
