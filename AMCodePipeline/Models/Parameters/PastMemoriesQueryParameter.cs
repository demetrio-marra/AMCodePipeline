namespace AMCodePipeline.Models.Parameters
{
    public sealed class PastMemoriesQueryParameter([FromKeyedServices("DisplayParametersSerializer")] IEWParameterSerializer displayValueSerializer) : BaseEWParameterConfiguration<IEnumerable<AgentMemoryItem>>
    {
        public override string Name => "Past memories query";

        public override IEWParameterSerializer DisplayValueSerializer => displayValueSerializer;
    }
}
