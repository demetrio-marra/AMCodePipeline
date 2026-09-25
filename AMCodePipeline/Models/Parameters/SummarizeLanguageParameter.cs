using AgentMesh.Models;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class SummarizeLanguageParameter : BaseEWParameterConfiguration<string>
    {
        public override string Name => "Summarize in language";
    }
}
