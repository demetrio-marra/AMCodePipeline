using AgentMesh.Models;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class IsSmallTalkParameter : BaseEWParameterConfiguration<bool?>
    {
        public override string Name => "Is small talk";
    }
}
