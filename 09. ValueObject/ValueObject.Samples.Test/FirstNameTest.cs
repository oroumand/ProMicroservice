using Xunit;

namespace ValueObject.Samples.Test;
public class FirstNameTest
{
    [Fact]
    public void name_cannot_be_empty()
    {
        Assert.Throws<ValueObjectInvalidState>(() => new FirstName(""));
    }
    [Fact]
    public void name_cannot_be_less_than_tow_char()
    {
        Assert.Throws<ValueObjectInvalidState>(() => new FirstName("1"));
    }

    [Fact]
    public void name_cannot_be_more_than_50_char()
    {
        Assert.Throws<ValueObjectInvalidState>(() => new FirstName("012345678901234567890123456789012345678901234567891"));
    }
}