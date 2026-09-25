using AgentMesh.Models;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class ExecutionErrorParameter : BaseEWParameterConfiguration<bool>
    {
        public override string Name => "Code execution error occurred flag";
    }
}
