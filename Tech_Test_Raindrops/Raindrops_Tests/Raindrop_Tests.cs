using NUnit.Framework;
using RaindropsLib;
using System;

namespace Raindrops_Tests
{
    public class Rainsdrop_Tests
    {
        [TestCase(1, "1")]
        [TestCase(-2, "-2")]
        [TestCase(4, "4")]
        [TestCase(-8, "-8")]
        [TestCase(11, "11")]
        public void NotDivisibleBy3_5_Or7(int input, string expected)
        {
            string actual = Raindrop.Input(input);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(3)]
        [TestCase(-6)]
        [TestCase(9)]
        [TestCase(-12)]
        [TestCase(18)]
        public void OnlyDivisibleBy3(int input)
        {
            string actual = Raindrop.Input(input);
            Assert.AreEqual("Pling", actual);
        }

        [TestCase(5)]
        [TestCase(-10)]
        [TestCase(20)]
        [TestCase(-25)]
        [TestCase(40)]
        public void OnlyDivisibleBy5(int input)
        {
            string actual = Raindrop.Input(input);
            Assert.AreEqual("Plang", actual);
        }

        [TestCase(7)]
        [TestCase(-14)]
        [TestCase(28)]
        [TestCase(-49)]
        [TestCase(56)]
        public void OnlyDivisibleBy7(int input)
        {
            string actual = Raindrop.Input(input);
            Assert.AreEqual("Plong", actual);
        }

        [TestCase(15)]
        [TestCase(-30)]
        [TestCase(45)]
        [TestCase(-60)]
        [TestCase(75)]
        public void DivisibleBy3And5ButNot7(int input)
        {
            string actual = Raindrop.Input(input);
            Assert.AreEqual("PlingPlang", actual);
        }

        [TestCase(21)]
        [TestCase(-42)]
        [TestCase(63)]
        [TestCase(-84)]
        [TestCase(126)]
        public void DivisibleBy3And7ButNot5(int input)
        {
            string actual = Raindrop.Input(input);
            Assert.AreEqual("PlingPlong", actual);
        }

        [TestCase(35)]
        [TestCase(-70)]
        [TestCase(140)]
        [TestCase(-175)]
        [TestCase(245)]
        public void DivisibleBy5And7ButNot3(int input)
        {
            string actual = Raindrop.Input(input);
            Assert.AreEqual("PlangPlong", actual);
        }

        [TestCase(0)]
        [TestCase(-105)]
        [TestCase(210)]
        [TestCase(-315)]
        [TestCase(420)]
        public void DivisibleBy3_5And7(int input)
        {
            string actual = Raindrop.Input(input);
            Assert.AreEqual("PlingPlangPlong", actual);
        }

        [Test]
        public void RespondsToInt32MaxValue()
        {
            string actual = Raindrop.Input(int.MaxValue);
            Assert.AreEqual("2147483647", actual);
        }

        [Test]
        public void RespondsToInt32MinValue()
        {
            string actual = Raindrop.Input(int.MinValue);
            Assert.AreEqual("-2147483648", actual);
        }

        [Test]
        public void RNGTest_PlingPresentInAnyNumberDivisibleBy3()
        {
            Random rng = new Random();
            int input = 3 * rng.Next(-1000000, 1000000);
            string output = Raindrop.Input(input);
            Assert.IsTrue(output.Contains("Pling"));
        }

        [Test]
        public void RNGTest_PlangPresentInAnyNumberDivisibleBy5()
        {
            Random rng = new Random();
            int input = 5 * rng.Next(-1000000, 1000000);
            string output = Raindrop.Input(input);
            Assert.IsTrue(output.Contains("Plang"));
        }

        [Test]
        public void RNGTest_PlongPresentInAnyNumberDivisibleBy7()
        {
            Random rng = new Random();
            int input = 7 * rng.Next(-1000000, 1000000);
            string output = Raindrop.Input(input);
            Assert.IsTrue(output.Contains("Plong"));
        }
    }
}