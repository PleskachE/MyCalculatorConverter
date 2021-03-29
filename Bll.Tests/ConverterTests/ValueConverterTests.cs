using NUnit.Framework;

using Bll.Executers;

using Models.ConverterModels.Entities;

namespace Bll.ConverterTests.Tests
{
    [TestFixture]
    public class ValueConverterTests
    {
        [TestCase("200Centimeter=Metre"    , "2")]
        [TestCase("3Mile=Metre"            , "4828,032")]
        [TestCase("12Yard=Metre"           , "10,9728")]
        [TestCase("12Kilometer=Mile"       , "7,456454")]
        [TestCase("34Ft=Metre"             , "10,3632")]
        public void TestLengthSystem(string text, string result)
        {
            var converter = new ValueConverter(new LengthSystem());
            Assert.AreEqual(result, converter.Calculation(text));           
        }

        [TestCase("0,5Hundredweight=Gram" , "50000")]
        [TestCase("32Pound=Kilogram"      , "14,514944")]
        [TestCase("12Carat=Milligram"     , "240")]
        [TestCase("1200Gram=Kilogram"     , "1,200")]
        [TestCase("15Ton=Stone"           , "2362,096849")]
        public void TestWeightSystem(string text, string result)
        {
            var converter = new ValueConverter(new WeightsSystem());
            Assert.AreEqual(result, converter.Calculation(text));
        }

        [TestCase("200Bit=Byte"           , "160,0")]
        [TestCase("3200Byte=Kilobyte"     , "3,125")]
        [TestCase("5000Kilobyte=Megabyte" , "4,882812")]
        public void TestMemorySystem(string text, string result)
        {
            var converter = new ValueConverter(new MemorySystem());
            Assert.AreEqual(result, converter.Calculation(text));
        }
    }
}
