using TestableCode.Interfaces;

namespace TestableCode.Calculator
{
    /// <summary>
    /// Class for subtraction operation.
    /// </summary>
    public class Subtraction : ICalculatorOperation
    {
        public string OperationName => "Subtract";

        /// <summary>
        /// Executes the subtraction operation with the given operands.
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The difference between the operands.</returns>
        public int Execute(int a, int b)
        {
            return a - b;
        }
    }
}
