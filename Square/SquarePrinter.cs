namespace Square
{
    public class SquarePrinter
    {
        public static void PrintRotatedSquare(int length)
        {
            if (length < 1 || length % 2 == 0) throw new ArgumentException("Only positive odd numbers are required");

            int middle = length / 2;

            for (int i = 0; i < length; i++)
            {
                var nrOfStars = (middle - Math.Abs(i - middle)) * 2 + 1;
                string row = new('*', nrOfStars);

                Console.WriteLine(PadCenter(row, length));
            }
        }

        private static string PadCenter(string str, int totalLength)
        {
            int emptySpace = totalLength - str.Length;
            int lengthAfterPadLeft = emptySpace / 2 + str.Length;
            return str.PadLeft(lengthAfterPadLeft).PadRight(totalLength);
        }
    }
}
