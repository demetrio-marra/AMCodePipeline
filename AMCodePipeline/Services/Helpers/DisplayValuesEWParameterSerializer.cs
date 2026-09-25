using AgentMesh.Models.Knowledge;

namespace AMCodePipeline.Services.Helpers
{
    public class DisplayValuesEWParameterSerializer : IEWParameterSerializer
    {
        public string Serialize<T>(T obj)
        {
            Debug.Print($"Serializing object of type {typeof(T).FullName} with value: {obj}");
            return obj switch
            {
                null => EWParameterConstants.NoDataPlaceholder,
                DateTime datetimeValue => datetimeValue.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss"),
                IEnumerable<string> missingValues => EWParameterDisplayUtils.GetListOfStringsDisplayValue(missingValues),
                IEnumerable<ContextMessage> contextMessages => EWParameterDisplayUtils.GetContextMessagesDisplayValue(contextMessages),
                IEnumerable<AgentMemoryQueryResultItem> queryResults => EWParameterDisplayUtils.GetAgentMemoryQueryResultsDisplayValue(queryResults),
                IEnumerable<AgentMemoryItem> memoryItems => EWParameterDisplayUtils.GetAgentMemoryItemsDisplayValue(memoryItems),
                KnowledgeQuery knowledgeQuery => EWParameterDisplayUtils.GetKnowledgeDisplayValue(knowledgeQuery),
                KnowledgeQueryResult knowledgeQueryResult => EWParameterDisplayUtils.GetKnowledgeQueryResultDisplayValue(knowledgeQueryResult),
                IEnumerable<KnowledgeContentItem> knowledgeContentItems => EWParameterDisplayUtils.GetDisplayValueForKnowledgeContentItem(knowledgeContentItems),
                _ => throw new ArgumentException($"Unsupported type '{obj.GetType().FullName}' for display value serialization.", nameof(obj))
            };
        }
    }
}
