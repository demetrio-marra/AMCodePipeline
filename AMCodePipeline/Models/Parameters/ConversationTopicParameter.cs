using AgentMesh.Models;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class ConversationTopicParameter : BaseEWParameterConfiguration<string>
    {
        public override string Name => "Conversation topic";
    }
}
