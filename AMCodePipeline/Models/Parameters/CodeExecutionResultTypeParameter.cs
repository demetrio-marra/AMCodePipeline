using AgentMesh.Models.CodeSandbox;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class CodeExecutionResultTypeParameter : BaseEWParameterConfiguration<SandboxResultType>
    {
        public override string Name => "Code execution result type";
    }
}
