namespace AMCodePipeline.Models.Parameters
{
    public sealed class PastMemoriesQueryResultsParameter([FromKeyedServices("DisplayParametersSerializer")] IEWParameterSerializer displayValueSerializer) : BaseEWParameterConfiguration<IEnumerable<AgentMemoryQueryResultItem>>
    {
        public override string Name => "Past memories query results";

        public override IEWParameterSerializer DisplayValueSerializer => displayValueSerializer;
    }
}
