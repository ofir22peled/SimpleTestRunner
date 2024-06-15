using TestableCode.Interfaces;

namespace TestableCode.Calculator
{
    /// <summary>
    /// Class for addition operation.
    /// </summary>
    public class Addition : ICalculatorOperation
    {
        public string OperationName => "Add";

        /// <summary>
        /// Executes the addition operation with the given operands.
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The sum of the operands.</returns>
        public int Execute(int a, int b)
        {
            return a + b;
        }
    }
}
