using System.Collections.Generic;

using NUnit.Framework;

using Models.Calculator.Abstraction;
using Models.Calculator.Entities;
using Models.Calculator.Entities.Operations;

namespace Algorithms.Tests
{
    [TestFixture]
    public class PolishNotationTests
    {
        #region TestMethods

        [TestCaseSource(nameof(DictionaryChecksAndResponses))]
        public void TestAlgorithmResult(KeyValuePair<string, ICollectionChar> pair)
        {
            var _algorithm = new PolishNotation();
            Assert.AreEqual(pair.Key, _algorithm.Result(pair.Value));
        }

        #endregion

        #region TestData

        private static ICollectionChar SymbalColl1 = new CollectionChar(new List<BaseSymbal>()
            {
                new Number("1"),
                new Summation(),
                new Number("2")
            }
        );
        private static ICollectionChar SymbalColl2 = new CollectionChar(new List<BaseSymbal>()
            {
                new Number("2"),
                new Summation(),
                new Number("2")
            }
        );
        private static ICollectionChar SymbalColl3 = new CollectionChar(new List<BaseSymbal>()
            {
                new Number("3"),
                new Multiply(),
                new Number("2")
            }
        );
        private static ICollectionChar SymbalColl4 = new CollectionChar(new List<BaseSymbal>()
            {
                new Number("3"),
                new Multiply(),
                new Number("2"),
                new Summation(),
                new Number("3,5")
            }
        );
        private static ICollectionChar SymbalColl5 = new CollectionChar(new List<BaseSymbal>()
            {
                new OpeningParenthesis(),
                new Number("3"),
                new Summation(),
                new Number("2"),
                new ClosingParenthesis(),
                new Division(),
                new Number("2")
            }
        );

        #endregion

        #region TestSource

        private static Dictionary<string, ICollectionChar> DictionaryChecksAndResponses = new Dictionary<string, ICollectionChar>()
        {
            ["3"] = SymbalColl1,
            ["4"] = SymbalColl2,
            ["6"] = SymbalColl3,
            ["9,5"] = SymbalColl4,
            ["2,5"] = SymbalColl5
        };

        #endregion
    }
}
