using static Calculator.Calculator;

namespace CalculatorTests
{
    public class Tests
    {
        [Test]
        [TestCase("(2 + 3) * (4 - 5)", ExpectedResult = -5)]
        [TestCase("15*8 + 13-(7+5)", ExpectedResult = 121)]
        [TestCase("5*6+0", ExpectedResult = 30)]
        [TestCase("(1-6)*2", ExpectedResult = -10)]
        [TestCase("2147483647 - 678*1", ExpectedResult = 2147482969)]
        [TestCase("155-150*(1-1)", ExpectedResult = 155)]
        [TestCase("608 - 8 + (4*5-10)", ExpectedResult = 610)]
        [TestCase("1000+1000 - 1000*10", ExpectedResult = -8000)]
        [TestCase("(((3 + 2) * (4 - 1)) / 5) + ((6 - 3) * (8 / 4))", ExpectedResult = 9)]
        [TestCase("(((10 - 2) * (7 + 3)) / (6 + 4)) + ((8 - 4) * (12 / 6))", ExpectedResult = 16)]
        [TestCase("(((5 * 2) / (4 + 1)) + ((6 - 3) * (8 / 4))) - (((7 + 2) * 3) / (12 - 6))", ExpectedResult = 4)]
        [TestCase("((((2 + 3) * (4 - 1)) / 5) + ((6 - 3) * (8 / 4))) - (((7 + 2) * 3) / (12 - 6))", ExpectedResult = 5)]
        public int CalculateWithPriority_ValidExpression_ReturnsCorrectResult(string expression) => Calculator.Calculator.CalculateWithPriority(expression);

        [Test]
        [TestCase("(2 + 3) * (4 - 5)", ExpectedResult = 15)]
        [TestCase("15*8 + 13-(7+5)", ExpectedResult = 131)]
        [TestCase("5*6+0", ExpectedResult = 30)]
        [TestCase("(1-6)*2", ExpectedResult = -10)]
        [TestCase("2147483647 - 678*1", ExpectedResult = 2147482969)]
        [TestCase("155-150*(1-1)", ExpectedResult = 4)]
        [TestCase("608 - 8 + (4*5-10)", ExpectedResult = 3010)]
        [TestCase("1000+1000 - 1000*10", ExpectedResult = 10000)]
        [TestCase("(((3 + 2) * (4 - 1)) / 5) + ((6 - 3) * (8 / 4))", ExpectedResult = 12)]
        [TestCase("(((10 - 2) * (7 + 3)) / (6 + 4)) + ((8 - 4) * (12 / 6))", ExpectedResult = 34)]
        [TestCase("(((5 * 2) / (4 + 1)) + ((6 - 3) * (8 / 4))) - (((7 + 2) * 3) / (12 - 6))", ExpectedResult = -5)]
        [TestCase("((((2 + 3) * (4 - 1)) / 5) + ((6 - 3) * (8 / 4))) - (((7 + 2) * 3) / (12 - 6))", ExpectedResult = -5)]
        public int CalculateWithoutPriority_ValidExpression_ReturnsCorrectResult(string expression) => Calculator.Calculator.CalculateWithoutPriority(expression);
    }
}