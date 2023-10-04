using LeapYearKata.Blazor;
using LeapYearKata.Blazor.ROP;

namespace LeapYear.UnitTest;

public class LeapYearServiceTests
{
    private readonly LeapYearService _service;

    public LeapYearServiceTests()
    {
        _service = new LeapYearService();
    }
    [Fact]
    public void ReturnFailResultWithThisIsNotLeapYearErrorMessage()
    {
        var result = _service.IsLeapYear(1997);
        Assert.False(result.IsSuccess);
        Assert.Equal("This is not a Leap Year!", result.Error);
    }
}