namespace AMCodePipeline.Models.Parameters
{
    public sealed class RelevantMessagesToSaveInAgentMemoryParameter([FromKeyedServices("DisplayParametersSerializer")] IEWParameterSerializer displayValueSerializer) : BaseEWParameterConfiguration<IEnumerable<ContextMessage>>
    {
        public override string Name => "Relevant messages to save in agent memory";

        public override IEWParameterSerializer DisplayValueSerializer => displayValueSerializer;
    }
}
