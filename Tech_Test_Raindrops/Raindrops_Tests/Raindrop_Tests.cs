using NUnit.Framework;
using RaindropsLib;

namespace Raindrops_Tests
{
    public class Rainsdrop_Tests
    {
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(4, "4")]
        [TestCase(8, "8")]
        [TestCase(11, "11")]
        public void NotDivisibleBy3_5_Or7(int input, string expected)
        {
            string actual = Raindrop.Input(input);
            Assert.AreEqual(expected,actual);
        }

        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        [TestCase(12)]
        [TestCase(18)]
        public void OnlyDivisibleBy3(int input)
        {
            string actual = Raindrop.Input(input);
            Assert.AreEqual("Pling", actual);
        }
    }
}