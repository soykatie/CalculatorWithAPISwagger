using static Calculator.Calculator;

namespace ExtractionParserTests
{
    public class Tests
    {
        [Test]
        [TestCase("(1100+(5+6*10)-13)*2", ExpectedResult = true)]
        [TestCase("11*5+6-13*2", ExpectedResult = true)]
        [TestCase("a+b*d-c", ExpectedResult = true)]
        [TestCase("(a*b-c)*e+(f/k+l)", ExpectedResult = true)]
        [TestCase("-a+5*b+6/k", ExpectedResult = true)]
        [TestCase("-(-a)+(5*b+6/k)*8", ExpectedResult = true)]
        [TestCase("-(-a)-(5b+6k)", ExpectedResult = true)]
        [TestCase("a", ExpectedResult = true)]
        [TestCase("cc21", ExpectedResult = true)]
        [TestCase("007", ExpectedResult = true)]
        [TestCase("-007", ExpectedResult = true)]

        [TestCase("2+*3-4*5", ExpectedResult = false)]
        [TestCase("100/10-20*6+/", ExpectedResult = false)]
        [TestCase("a*/6+4", ExpectedResult = false)]
        [TestCase("(d+567)/9*(32-12", ExpectedResult = false)]
        [TestCase("1 2", ExpectedResult = false)]
        [TestCase("+-", ExpectedResult = false)]
        [TestCase("--100", ExpectedResult = false)]
        [TestCase("300+21cc. -6", ExpectedResult = false)]
        [TestCase("(1100+(5+6*10)&13)*2", ExpectedResult = false)]
        [TestCase("678*12*(23+15-9*0", ExpectedResult = false)]
        [TestCase("p9086+12  5", ExpectedResult = false)]
        public bool IsValidExpression_ValidExpression_ReturnsCorrectResult(string expression)
        {
            ExpressionParser parser = new ExpressionParser();
            bool result = parser.IsValidExpression(expression);
            return result;
        }
    }
}