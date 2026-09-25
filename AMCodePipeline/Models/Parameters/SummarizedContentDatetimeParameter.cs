using AgentMesh.Models;
using AgentMesh.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class SummarizedContentDatetimeParameter([FromKeyedServices("DisplayParametersSerializer")] IEWParameterSerializer displayValueSerializer) : BaseEWParameterConfiguration<DateTime>
    {
        public override string Name => "Summarized content datetime";

        public override IEWParameterSerializer DisplayValueSerializer => displayValueSerializer;
    }
}
