namespace AMCodePipeline.Models.Parameters
{
    public sealed class KnowledgeQueryParameter([FromKeyedServices("DisplayParametersSerializer")] IEWParameterSerializer displayValueSerializer) : BaseEWParameterConfiguration<AgentMesh.Models.Knowledge.KnowledgeQuery>
    {
        public override string Name => "Knowledge query";

        public override IEWParameterSerializer DisplayValueSerializer => displayValueSerializer;
    }
}
