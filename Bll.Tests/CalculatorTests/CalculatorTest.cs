using Algorithms;

using Bll.Executers;

using NUnit.Framework;

namespace Bll.Tests.CalculatorTests
{
    [TestFixture]
    public class CalculatorTest
    {
        [TestCase("2+3*2"         ,"8")]
        [TestCase("2+2*2"         , "6")]
        [TestCase("(2+3)*2"       , "10")]
        [TestCase("(2-3)*2"       , "-2")]
        [TestCase("(2+3)*2+(5-2)" , "13")]
        public void CalculatorTestCalculationReversePolishNotation(string text, string result)
        {
            var calc = new Calculator(new ReversePolishNotation());
            Assert.AreEqual(result, calc.Calculation(text));
        }
    }
}
