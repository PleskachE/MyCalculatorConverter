using Bll.ValueConverterSupportTools;

using NUnit.Framework;

namespace Bll.Tests.ConverterTests
{
    [TestFixture]
    public class UnitsParserTests
    {
        [TestCase]
        public void GetFirstUnitTest()
        {
            Assert.IsNotNull(UnitsParser.GetFirstUnit());
        }

        [TestCase]
        public void GetLastUnitTest()
        {
            Assert.IsNotNull(UnitsParser.GetLastUnit());
        }
    }
}
