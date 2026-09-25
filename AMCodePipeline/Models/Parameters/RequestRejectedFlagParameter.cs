using AgentMesh.Models;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class RequestRejectedFlagParameter : BaseEWParameterConfiguration<bool>
    {
        public override string Name => "Request rejected flag";
    }
}
