namespace AMCodePipeline.Services.EWSteps
{
    public class KnowledgeForCoderEWCodeStep(
        IKnowledgeService knowledgeService,
        KnowledgeQueryForCoderParameter knowledgeQueryParameter) : IEWStep
    {
        public string Name => "KnowledgeForCoder Service Search";

        public IEnumerable<Type> InputParameterTypes => [typeof(KnowledgeQueryForCoderParameter)];
        public IEnumerable<Type> OutputParameterTypes => [typeof(KnowledgeQueryForCoderResultParameter)];

        public async Task<EWStepExecutionResult> ExecuteAsync(IReadOnlyDictionary<Type, object?> Values, CancellationToken cancellationToken = default)
        {
            var query = knowledgeQueryParameter.ValueAs(Values[typeof(KnowledgeQueryForCoderParameter)])!;
            var knowledgeQueryResult = await knowledgeService.QueryKnowledgeAsync(new AgentMesh.Models.Knowledge.KnowledgeQuery
            {
                QueryText = query.QueryText,
                QueryRetrievalKind = Enum.Parse<AgentMesh.Models.Knowledge.KnowledgeQueryRetrievalKind>(query.QueryRetrievalKind.ToString()),
                PrimaryRelevanceKeywords = query.PrimaryRelevanceKeywords,
                SecondaryRelevanceKeywords = query.SecondaryRelevanceKeywords,
                MaxResults = query.MaxResults,
                IncludeEntities = query.IncludeEntities,
                IncludeRelations = query.IncludeRelations
            }, cancellationToken);

            // we must filter documents that includes the "scope: api-documentation" text in their Frontmatter
            knowledgeQueryResult.Contents = knowledgeQueryResult.Contents.Where(c => c.Content.Contains("scope: api-documentation", StringComparison.OrdinalIgnoreCase));

            return new EWStepExecutionResult
            {
                OutputMutations = new Dictionary<Type, object?>
                {
                    { typeof(KnowledgeQueryForCoderResultParameter), knowledgeQueryResult }
                }
            };
        }
    }
}
