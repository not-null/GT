namespace Square.UnitTests
{
    [TestClass]
    public class SquarePrinterTests
    {
        [TestMethod]
        public void PrintRotatedSquare_FiveLength_PrintsCorrect()
        {
            // capture Console.WriteLine()
            using var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            SquarePrinter.PrintRotatedSquare(5);

            var output = stringWriter.ToString();

            var expected = """
                      *  
                     *** 
                    *****
                     *** 
                      *  

                    """;

            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void PrintRotatedSquare_NineLength_PrintsCorrect()
        {
            // capture Console.WriteLine()
            using var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            SquarePrinter.PrintRotatedSquare(9);

            var output = stringWriter.ToString();

            var expected = """
                        *    
                       ***   
                      *****  
                     ******* 
                    *********
                     ******* 
                      *****  
                       ***   
                        *    

                    """;

            Assert.AreEqual(expected, output);
        }

        [TestMethod]
        public void PrintRotatedSquare_EvenLength_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => SquarePrinter.PrintRotatedSquare(4));
        }

        [TestMethod]
        public void PrintRotatedSquare_NegativeLength_ThrowsException()
        {
            Assert.ThrowsException<ArgumentException>(() => SquarePrinter.PrintRotatedSquare(-1));
        }
    }
}
