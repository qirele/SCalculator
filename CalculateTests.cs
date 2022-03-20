using NUnit.Framework;


namespace scienceCalcCLI
{
    class CalculateTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [TestCase(4, 4, 16)]
        [TestCase(3, 1, 3)]
        [TestCase(5, 2, 10)]
        public void calculate_Multiplication_Test(int a, int b, double expectedResult)
        {
            var actual = Program.calculate($"calc {a} * {b}");

            Assert.That(actual == expectedResult);


        }


        [TestCase(4, 4, 8)]
        [TestCase(3, 1, 4)]
        [TestCase(5, 2, 7)]
        public void calculate_Addition_Test(int a, int b, double expectedResult)
        {
            var actual = Program.calculate($"calc {a} + {b}");

            Assert.That(actual == expectedResult);

        }

        [TestCase(4, 4, 1)]
        [TestCase(3, 6, 0.5)]
        [TestCase(5, 2, 2.5)]
        public void calculate_Division_Test(int a, int b, double expectedResult)
        {
            var actual = Program.calculate($"calc {a} / {b}");

            Assert.That(actual == expectedResult);

        }
    }
}
