using AgentMesh.Models;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class RequestRejectedReasonParameter : BaseEWParameterConfiguration<string>
    {
        public override string Name => "Request rejected reason";
    }
}
