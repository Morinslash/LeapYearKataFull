using LeapYearKata.Blazor;

namespace LeapYear.UnitTest;

public class LeapYearServiceTests
{
    private readonly LeapYearService _service = new();

    [Fact]
    public void ReturnResultFailWithErrorMessageIfYearNotDivisibleBy4()
    {
        var result = _service.IsItLeap(1997);
        Assert.False(result.IsSuccess);
        Assert.Equal("This is not a Leap Year!", result.Error);
    }

    [Fact]
    public void ReturnSuccessResultIfYearIsDivisibleBy4()
    {
        var result = _service.IsItLeap(1996);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void ReturnSuccessResultIfYearIsDivisibleBy400()
    {
        var result = _service.IsItLeap(1600);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public void ReturnResultFailWithErrorMessageIfYearDivisibleBy100ButNot400()
    {
        var result = _service.IsItLeap(1800);
        Assert.False(result.IsSuccess);
        Assert.Equal("This is not a Leap Year!", result.Error); 
    }
}