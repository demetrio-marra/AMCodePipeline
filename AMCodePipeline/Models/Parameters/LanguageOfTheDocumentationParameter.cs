using AgentMesh.Models;

namespace AMCodePipeline.Models.Parameters
{
    public sealed class LanguageOfTheDocumentationParameter : BaseEWParameterConfiguration<string>
    {
        public override string Name => "Language the documentation is written in";
    }
}
