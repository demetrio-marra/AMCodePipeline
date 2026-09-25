using AgentMesh.Models;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class UserLastRequestParameter : BaseEWParameterConfiguration<string>
    {
        public override string Name => "User last request";
    }
}
