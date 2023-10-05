using LeapYearKata.Blazor.ROP;

namespace LeapYearKata.Blazor;

public class LeapYearService
{
    public Result<bool> IsItLeap(int year)
    {
        return IsLeap(year) ? Result<bool>.Success(true) : Result<bool>.Fail("This is not a Leap Year!");
    }

    private bool IsLeap(int year)
    {
        if (year % 400 == 0) return true;
        if (year % 100 == 0) return false;
        if (year % 4 == 0) return true;
        return false;
    }
}