using AgentMesh.Models;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class UserIntentParameter : BaseEWParameterConfiguration<string>
    {
        public override string Name => "User intent";
    }
}
