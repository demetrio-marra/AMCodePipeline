using AgentMesh.Models;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class SandboxExecutionIdParameter : BaseEWParameterConfiguration<string>
    {
        public override string Name => "Code execution id";
    }
}
