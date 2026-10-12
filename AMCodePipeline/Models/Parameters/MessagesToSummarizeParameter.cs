namespace AMCodePipeline.Models.Parameters
{
    public sealed class MessagesToSummarizeParameter([FromKeyedServices("DisplayParametersSerializer")] IEWParameterSerializer displayValueSerializer) : BaseEWParameterConfiguration<IEnumerable<ContextMessage>>
    {
        public override string Name => "Messages to summarize";

        public override IEWParameterSerializer DisplayValueSerializer => displayValueSerializer;
    }
}
