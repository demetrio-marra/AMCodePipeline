namespace AMCodePipeline.Configuration
{
    public class CodePipelineConfiguration
    {
        public const string SectionName = "CodePipeline";

        public bool EnableMemoryService { get; set; } = true;
        public bool EnableDomainExpert { get; set; } = true;
        public string LanguageOfKnowledgeBase { get; set; } = string.Empty;
    }
}
