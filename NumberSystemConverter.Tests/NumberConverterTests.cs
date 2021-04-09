using NUnit.Framework;

namespace NumberSystemConverter.Tests
{
    [TestFixture]
    public class NumberConverterTests
    {
        #region TestMethods

        [TestCase("0,23", "0,001110101")]
        [TestCase("5"      , "101")]
        [TestCase("124"    , "1111100")]
        [TestCase("523"    , "1000001011")]
        [TestCase("74,116" , "1001010,000111011")]
        [TestCase("az.l+"  , "0")]
        [TestCase("az37+"  , "100101")]
        public void TestDecimalToBinaryConverter(string text, string result)
        {
            var converter = new DecimalToBinaryConverter();
            Assert.AreEqual(result, converter.Conversion(text));
        }

        #endregion
    }
}
