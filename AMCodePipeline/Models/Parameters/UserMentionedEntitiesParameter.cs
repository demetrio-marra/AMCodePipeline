using AgentMesh.Models;
using AgentMesh.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class UserMentionedEntitiesParameter([FromKeyedServices("DisplayParametersSerializer")] IEWParameterSerializer displayValueSerializer) : BaseEWParameterConfiguration<IEnumerable<string>>
    {
        public override string Name => "User mentioned entities";

        public override IEWParameterSerializer DisplayValueSerializer => displayValueSerializer;
    }
}
