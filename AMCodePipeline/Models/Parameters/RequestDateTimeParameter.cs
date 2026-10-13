namespace AMCodePipeline.Models.Parameters
{
    public sealed class RequestDateTimeParameter([FromKeyedServices("DisplayParametersSerializer")] IEWParameterSerializer displayValueSerializer) : BaseEWParameterConfiguration<DateTime>
    {
        public override string Name => "Current datetime";

        public override IEWParameterSerializer DisplayValueSerializer => displayValueSerializer;
    }
}
