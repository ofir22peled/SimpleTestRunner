namespace TestableCode
{
    /// <summary>
    /// Simple calculator class for demonstration purposes.
    /// </summary>
    public class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Dividing by zero is a world crime.");
            }

            return a / b;
        }

        public int Mult(int a, int b)
        {
            return a * b;
        }
    }
}