using LeapYearKata.Blazor.ROP;

namespace LeapYearKata.Blazor;

public class LeapYearService
{
    public Result<bool> IsLeapYear(int year)
    {
        return new Result<bool>(false, "This is not a Leap Year!", false);
    }
}