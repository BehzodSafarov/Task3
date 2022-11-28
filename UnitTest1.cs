using Task3.Services;
using Xunit;

namespace UnitTest;

public class UnitTest1
{
    [Theory]
    [InlineData("1234","1697", "M:0 P:1")]
    [InlineData("1284","1682", "M:1 P:2")] 
    

    public void ValidateNumberIsTrue(string number, string insertNumber,string expected)
    {
        var calculateService = new CalculateService();
        var answer =  calculateService.ValidateDigits(number,insertNumber);
        
        string result = $"M:{answer[0]} P:{answer[1]}";

        Assert.Equal(result,expected);
    }
}