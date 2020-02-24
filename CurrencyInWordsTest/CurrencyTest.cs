using Microsoft.VisualStudio.TestTools.UnitTesting;
using CurrencyNS;

namespace CurrencyInWordsTest
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void ZeroCurrencyCase()
        {
            decimal input = 0;
            string result = ConverToWords.ToWords(input);
            Assert.AreEqual("Zero Dollars", result, "Zero input not handled appropriately");
        }

        [TestMethod]
        public void ValidCurrencyCase()
        {
            decimal input = 543.35m;
            string result = ConverToWords.ToWords(input);
            Assert.AreEqual("Five Hundred Fourty Three Dollars and Thirty Five Cents", result, "Invalid conversion of valid currency input");
        }

        [TestMethod]
        public void ValidCurrencyWithoutCentsCase()
        {
            decimal input = 543m;
            string result = ConverToWords.ToWords(input);
            Assert.AreEqual("Five Hundred Fourty Three Dollars", result, "Invalid conversion of valid currency input without cents");
        }
    }
}
