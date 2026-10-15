using AgentMesh.Contracts.Models.AgentMemory;
using AMCodePipeline.Utils;
using Xunit;

namespace AMCodePipelineTests;

public class EWParameterDisplayUtilsTests
{
    [Fact]
    public void GetListOfStringsDisplayValue_ReturnsPlaceholder_WhenValuesAreNullOrEmpty()
    {
        Assert.Equal("(None)", EWParameterDisplayUtils.GetListOfStringsDisplayValue(null));
        Assert.Equal("(None)", EWParameterDisplayUtils.GetListOfStringsDisplayValue([]));
    }

    [Fact]
    public void GetListOfStringsDisplayValue_FormatsValuesAsBulletList()
    {
        var result = EWParameterDisplayUtils.GetListOfStringsDisplayValue(["first", "second"]);

        Assert.Equal("- first\n- second", result);
    }

    [Fact]
    public void GetAgentMemoryItemsDisplayValue_ReturnsPlaceholder_WhenItemsAreNullOrEmpty()
    {
        Assert.Equal("(None)", EWParameterDisplayUtils.GetAgentMemoryItemsDisplayValue(null));
        Assert.Equal("(None)", EWParameterDisplayUtils.GetAgentMemoryItemsDisplayValue([]));
    }

    [Fact]
    public void GetAgentMemoryItemsDisplayValue_FormatsMemoryAsBulletList()
    {
        var result = EWParameterDisplayUtils.GetAgentMemoryItemsDisplayValue(
        [
            new AgentMemoryItem { Memory = "first memory" },
            new AgentMemoryItem { Memory = "second memory" }
        ]);

        Assert.Equal("- first memory\n- second memory", result);
    }
}
