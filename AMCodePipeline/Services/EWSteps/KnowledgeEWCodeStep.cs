using AgentMesh.Models.Knowledge;

namespace AMCodePipeline.Services.EWSteps
{
    public class KnowledgeEWCodeStep(
        IKnowledgeService knowledgeService,
        KnowledgeQueryParameter knowledgeQueryParameter) : IEWStep
    {
        public string Name => "Knowledge Service Search";

        public IEnumerable<Type> InputParameterTypes => [typeof(KnowledgeQueryParameter)];
        public IEnumerable<Type> OutputParameterTypes => [typeof(KnowledgeQueryResultParameter)];

        public async Task<EWStepExecutionResult> ExecuteAsync(IReadOnlyDictionary<Type, object?> Values, CancellationToken cancellationToken = default)
        {
            var query = knowledgeQueryParameter.ValueAs(Values[typeof(KnowledgeQueryParameter)])!;
            var knowledgeQueryResult = await knowledgeService.QueryKnowledgeAsync(new KnowledgeQuery
            {
                QueryText = query.QueryText,
                QueryRetrievalKind = Enum.Parse<KnowledgeQueryRetrievalKind>(query.QueryRetrievalKind.ToString()),
                PrimaryRelevanceKeywords = query.PrimaryRelevanceKeywords,
                SecondaryRelevanceKeywords = query.SecondaryRelevanceKeywords,
                MaxResults = query.MaxResults,
                IncludeEntities = query.IncludeEntities,
                IncludeRelations = query.IncludeRelations
            }, cancellationToken);

            return new EWStepExecutionResult
            {
                OutputMutations = new Dictionary<Type, object?>
                {
                    { typeof(KnowledgeQueryResultParameter), knowledgeQueryResult }
                }
            };
        }
    }
}
