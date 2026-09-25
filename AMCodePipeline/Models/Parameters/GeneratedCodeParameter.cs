using AgentMesh.Models;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class GeneratedCodeParameter : BaseEWParameterConfiguration<string>
    {
        public override string Name => "Generated code";
    }
}
