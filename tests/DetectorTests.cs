using Xunit;
using TraditionalAmlEngine;
using FuzzyAmlEngine;

namespace AmlEngine.Tests;

public class DetectorTests
{
    private readonly TraditionalDetector _traditional = new();
    private readonly FuzzyDetector _fuzzy = new();

    [Fact]
    public void Traditional_HighAmountHighFreq_IsFraud()
    {
        Assert.True(_traditional.IsFraud(new("T", 12000, 8)));
    }

    [Fact]
    public void Traditional_LowAmount_NotFraud()
    {
        Assert.False(_traditional.IsFraud(new("T", 5000, 8)));
    }

    [Fact]
    public void Fuzzy_HighRisk_ScoreAbove70()
    {
        Assert.True(_fuzzy.Score(new("T", 20000, 10)) > 70);
    }

    [Fact]
    public void Fuzzy_LowRisk_ScoreBelow40()
    {
        Assert.True(_fuzzy.Score(new("T", 3000, 1)) <= 40);
    }

    [Theory]
    [InlineData(80, "High Risk")]
    [InlineData(50, "Medium Risk")]
    [InlineData(30, "Low Risk")]
    public void Fuzzy_Label_CorrectCategory(double score, string expected)
    {
        Assert.Equal(expected, _fuzzy.Label(score));
    }
}
