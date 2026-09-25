using AgentMesh.Models;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class SummarizedContentParameter : BaseEWParameterConfiguration<string>
    {
        public override string Name => "Summarized content";
    }
}
