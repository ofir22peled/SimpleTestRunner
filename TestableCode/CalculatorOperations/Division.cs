using System;
using TestableCode.Interfaces;

namespace TestableCode.Calculator
{
    /// <summary>
    /// Class for division operation.
    /// </summary>
    public class Division : ICalculatorOperation
    {
        public string OperationName => "Divide";

        /// <summary>
        /// Executes the division operation with the given operands.
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The quotient of the operands.</returns>
        /// <exception cref="DivideByZeroException">Thrown when the second operand is zero.</exception>
        public int Execute(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Dividing by zero is not allowed.");
            }
            return a / b;
        }
    }
}
