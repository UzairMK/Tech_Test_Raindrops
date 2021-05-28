using NUnit.Framework;
using RaindropsLib;

namespace Raindrops_Tests
{
    public class Rainsdrop_Tests
    {
        [TestCase(1, "1")]
        [TestCase(-2, "-2")]
        [TestCase(4, "4")]
        [TestCase(-8, "-8")]
        [TestCase(11, "11")]
        public void NotDivisibleBy3_5_Or7_ReturnsNumberAsString(int input, string expected)
        {
            string actual = Raindrop.Input(input);
            Assert.That(expected, Is.EqualTo(actual));
        }

        [TestCase(3)]
        [TestCase(-6)]
        [TestCase(9)]
        [TestCase(-12)]
        [TestCase(18)]
        public void DivisibleBy3ButNotBy5And7_ReturnsPling(int input)
        {
            string actual = Raindrop.Input(input);
            Assert.That("Pling", Is.EqualTo(actual));
        }

        [TestCase(5)]
        [TestCase(-10)]
        [TestCase(20)]
        [TestCase(-25)]
        [TestCase(40)]
        public void DivisibleBy5ButNotBy3And7_ReturnsPlang(int input)
        {
            string actual = Raindrop.Input(input);
            Assert.That("Plang", Is.EqualTo(actual));
        }

        [TestCase(7)]
        [TestCase(-14)]
        [TestCase(28)]
        [TestCase(-49)]
        [TestCase(56)]
        public void DivisibleBy7ButNotBy3And5_ReturnsPlong(int input)
        {
            string actual = Raindrop.Input(input);
            Assert.That("Plong", Is.EqualTo(actual));
        }

        [TestCase(15)]
        [TestCase(-30)]
        [TestCase(45)]
        [TestCase(-60)]
        [TestCase(75)]
        public void DivisibleBy3And5ButNot7_ReturnsPlingPlang(int input)
        {
            string actual = Raindrop.Input(input);
            Assert.That("PlingPlang", Is.EqualTo(actual));
        }

        [TestCase(21)]
        [TestCase(-42)]
        [TestCase(63)]
        [TestCase(-84)]
        [TestCase(126)]
        public void DivisibleBy3And7ButNot5_ReturnsPlingPlong(int input)
        {
            string actual = Raindrop.Input(input);
            Assert.That("PlingPlong", Is.EqualTo(actual));
        }

        [TestCase(35)]
        [TestCase(-70)]
        [TestCase(140)]
        [TestCase(-175)]
        [TestCase(245)]
        public void DivisibleBy5And7ButNot3_ReturnsPlangPlong(int input)
        {
            string actual = Raindrop.Input(input);
            Assert.That("PlangPlong", Is.EqualTo(actual));
        }

        [TestCase(0)]
        [TestCase(-105)]
        [TestCase(210)]
        [TestCase(-315)]
        [TestCase(420)]
        public void DivisibleBy3_5And7_ReturnsPlingPlangPlong(int input)
        {
            string actual = Raindrop.Input(input);
            Assert.That("PlingPlangPlong", Is.EqualTo(actual));
        }

        [Test]
        public void RespondsToInt32MaxValue_ReturnsInt32MaxValueAsString()
        {
            string actual = Raindrop.Input(int.MaxValue);
            Assert.That("2147483647", Is.EqualTo(actual));
        }

        [Test]
        public void RespondsToInt32MinValue_ReturnsInt32MinValueAsString()
        {
            string actual = Raindrop.Input(int.MinValue);
            Assert.That("-2147483648", Is.EqualTo(actual));
        }

        [TestCase(3)]
        [TestCase(-15)]
        [TestCase(21)]
        [TestCase(-105)]
        public void PlingPresentInAnyNumberDivisibleBy3_ReturnedStringContainsPling(int input)
        {
            string output = Raindrop.Input(input);
            Assert.That(output.Contains("Pling"), Is.True);
        }

        [TestCase(5)]
        [TestCase(-15)]
        [TestCase(35)]
        [TestCase(-105)]
        public void PlangPresentInAnyNumberDivisibleBy5_ReturnedStringContainsPlang(int input)
        {
            string output = Raindrop.Input(input);
            Assert.That(output.Contains("Plang"), Is.True);
        }

        [TestCase(7)]
        [TestCase(-21)]
        [TestCase(35)]
        [TestCase(-105)]
        public void PlongPresentInAnyNumberDivisibleBy7_ReturnedStringContainsPlong(int input)
        {
            string output = Raindrop.Input(input);
            Assert.That(output.Contains("Plong"), Is.True);
        }

        [TestCase(15)]
        [TestCase(-105)]
        [TestCase(-120)]
        [TestCase(210)]
        public void PlingPlangPresentInAnyNumberDivisibleBy3And5_ReturnedStringContainsPlingPlang(int input)
        {
            string output = Raindrop.Input(input);
            Assert.That(output.Contains("PlingPlang"), Is.True);
        }

        [TestCase(35)]
        [TestCase(-105)]
        [TestCase(-140)]
        [TestCase(210)]
        public void PlangPlongPresentInAnyNumberDivisibleBy5And7_ReturnedStringContainsPlangPlong(int input)
        {
            string output = Raindrop.Input(input);
            Assert.That(output.Contains("PlangPlong"), Is.True);
        }
    }
}