namespace TestableCode.Interfaces
{
    public interface ICalculatorOperation
    {
        /// <summary>
        /// Gets the name of the operation.
        /// </summary>
        string OperationName { get; }

        /// <summary>
        /// Executes the operation with the given operands.
        /// </summary>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        int Execute(int a, int b);
    }
}
