using TestableCode.Interfaces;

namespace TestableCode.Calculator
{
    /// <summary>
    /// Class for subtraction operation.
    /// </summary>
    public class Multiplication : ICalculatorOperation
    {
         public string OperationName => "Multiply";

        /// <summary>
        /// Executes the multiplication operation with the given operands.
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The multiplication of the operands.</returns>
        public int Execute(int a, int b)
        {
            return a * b;
        }
    }
}

