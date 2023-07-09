using FluentAssertions;

namespace PatternsDemo;

public class DeclarationAndTypePatternTest
{
    [Fact]
    public void Is_Type_Pattern()
    {
        int? x = 7;
        (x is not null).Should().BeTrue();
        x = null;
        (x is null).Should().BeTrue();

        object obj = "Hi";
        (obj is string).Should().BeTrue();

        x = 12;
        if (x is int number)
        {
            number.Should().Be(12);
        }
    }
}
