using AgentMesh.Models;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class PipelineResultDataParameter : BaseEWParameterConfiguration<string>
    {
        public override string Name => "Pipeline result data";
    }
}
