using System;
using System.Collections.Generic;
using TestableCode.Interfaces;

namespace TestableCode.Calculator
{
    /// <summary>
    /// Calculator class that dynamically registers and executes operations.
    /// </summary>
    public class Calculator
    {
        private readonly Dictionary<string, ICalculatorOperation> _operations = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="Calculator"/> class
        /// and registers the default operations.
        /// </summary>
        public Calculator()
        {
            RegisterOperation(new Addition());
            RegisterOperation(new Subtraction());
            RegisterOperation(new Division());
            RegisterOperation(new Multiplication());
        }

        /// <summary>
        /// Registers a new operation.
        /// </summary>
        /// <param name="operation">The operation to register.</param>
        /// <exception cref="ArgumentNullException">Thrown when the operation is null.</exception>
        public void RegisterOperation(ICalculatorOperation operation)
        {
            if (operation == null) throw new ArgumentNullException(nameof(operation));
            _operations[operation.OperationName] = operation;
        }

        /// <summary>
        /// Executes the specified operation with the given operands.
        /// </summary>
        /// <param name="operationName">The name of the operation to execute.</param>
        /// <param name="a">The first operand.</param>
        /// <param name="b">The second operand.</param>
        /// <returns>The result of the operation.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the operation is not found.</exception>
        public int ExecuteOperation(string operationName, int a, int b)
        {
            if (!_operations.ContainsKey(operationName))
            {
                throw new InvalidOperationException($"Operation '{operationName}' not found.");
            }

            return _operations[operationName].Execute(a, b);
        }
    }
}
