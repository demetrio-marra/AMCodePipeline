using AgentMesh.Models;
using AMCodePipeline.Models.RequestAnalysis;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class IntentCategoryParameter : BaseEWParameterConfiguration<UserIntentCategory?>
    {
        public override string Name => "Intent category";
    }
}
