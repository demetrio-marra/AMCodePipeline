namespace AMCodePipeline.Models.Parameters
{
    public sealed class InitialContextMessagesParameter([FromKeyedServices("DisplayParametersSerializer")] IEWParameterSerializer displayValueSerializer) : BaseEWParameterConfiguration<IEnumerable<ContextMessage>>
    {
        public override string Name => "Initial context messages";

        public override IEWParameterSerializer DisplayValueSerializer => displayValueSerializer;
    }
}

