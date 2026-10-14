using AMCodePipeline.Utils;
using Xunit;

namespace AMCodePipelineTests;

public class SourceCodeUtilsTests
{
    [Fact]
    public void GetSourceCodeWithLineNumbers_ReturnsNull_WhenSourceIsNull()
    {
        var result = SourceCodeUtils.GetSourceCodeWithLineNumbers(null);

        Assert.Null(result);
    }

    [Fact]
    public void GetSourceCodeWithLineNumbers_HandlesMixedLineEndingsAndTrailingNewline()
    {
        var result = SourceCodeUtils.GetSourceCodeWithLineNumbers("alpha\r\nbeta\rgamma\n");
        var expected = string.Join(Environment.NewLine,
            "[1] alpha",
            "[2] beta",
            "[3] gamma",
            "[4] ",
            "");

        Assert.Equal(expected, result);
    }

    [Fact]
    public void GetSourceCodeWithLineNumbers_PadsNumbersToTheMaximumWidth()
    {
        var sourceCode = string.Join("\n", Enumerable.Range(1, 10).Select(number => $"line {number}"));

        var result = SourceCodeUtils.GetSourceCodeWithLineNumbers(sourceCode);
        var lines = result!.Split(Environment.NewLine);

        Assert.Equal("[ 1] line 1", lines[0]);
        Assert.Equal("[10] line 10", lines[9]);
    }
}
