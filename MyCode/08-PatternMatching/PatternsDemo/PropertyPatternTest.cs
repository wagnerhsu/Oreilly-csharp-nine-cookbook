namespace PatternsDemo;
public class PropertyPatternTest
{
    [Fact]
    public void Basic_Property_Test()
    {
        object obj = "Hello";
        StringLengthThan2(obj).Should().Be(1);
        obj = "Hi";
        StringLengthThan2(obj).Should().Be(5);
        obj = string.Empty;
        StringLengthThan2(obj).Should().Be(2);
        obj = null;
        StringLengthThan2(obj).Should().Be(4);
        int StringLengthThan2(object obj)
        {

            var result = obj switch
            {
                string { Length: > 2 } => 1,
                string { Length: 0 or 1 } => 2,
                int => 3,
                null => 4,
                _ => 5
            };
            return result;

        }
    }
}
