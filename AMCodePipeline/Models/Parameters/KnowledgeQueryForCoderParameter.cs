namespace AMCodePipeline.Models.Parameters
{
    public sealed class KnowledgeQueryForCoderParameter([FromKeyedServices("DisplayParametersSerializer")] IEWParameterSerializer displayValueSerializer) : BaseEWParameterConfiguration<AgentMesh.Models.Knowledge.KnowledgeQuery>
    {
        public override string Name => "Knowledge query for coder";

        public override IEWParameterSerializer DisplayValueSerializer => displayValueSerializer;
    }
}
