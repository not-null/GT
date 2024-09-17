namespace Fibonacci.UnitTests
{
    [TestClass]
    public class FibonacciGeneratorTests
    {
        [TestMethod]
        public void GetNthFibonacciNumber_FifthNumber_ReturnsThree()
        {
            var expected = 3;
            Assert.AreEqual(expected, FibonacciGenerator.GetNthFibonacciNumber(5));
        }

        [TestMethod]
        public void GetNthFibonacciNumber_ThreeHundredthNumber_ReturnsBigNumber()
        {
            var expected = "137347080577163115432025771710279131845700275212767467264610201"; // https://r-knott.surrey.ac.uk/Fibonacci/fibtable.html
            Assert.AreEqual(expected, FibonacciGenerator.GetNthFibonacciNumber(300).ToString());
        }

        [TestMethod]
        public void GetNthFibonacciNumber_Zero_ThrowsException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => FibonacciGenerator.GetNthFibonacciNumber(0));
        }

        // --- Recursive variant ---

        [TestMethod]
        public void GetNthFibonacciNumberRec_FifthNumber_ReturnsThree()
        {
            uint expected = 3;
            Assert.AreEqual(expected, FibonacciGenerator.GetNthFibonacciNumberRec(5));
        }

        [TestMethod]
        public void GetNthFibonacciNumberRec_FortiethNumber_ReturnsCorrect()
        {
            // dont go higher than this unless you have patience
            uint expected = 63245986;
            Assert.AreEqual(expected, FibonacciGenerator.GetNthFibonacciNumberRec(40));
        }
    }
}
