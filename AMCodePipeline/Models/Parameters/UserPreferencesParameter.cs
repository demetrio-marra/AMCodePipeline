using AgentMesh.Models;
using AgentMesh.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class UserPreferencesParameter([FromKeyedServices("DisplayParametersSerializer")] IEWParameterSerializer displayValueSerializer) : BaseEWParameterConfiguration<IEnumerable<string>>
    {
        public override string Name => "User preferences";

        public override IEWParameterSerializer DisplayValueSerializer => displayValueSerializer;
    }
}
