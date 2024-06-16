using TestableCode.Interfaces;
using TestRunner.Assertions;
using TestRunner.Attributes;

namespace TestableCode.Calculator
{
    /// <summary>
    /// Tests for the Calculator class.
    /// </summary>
    public class CalculatorTests : ICalculatorTests
    {
        /// <summary>
        /// Tests the Add method.
        /// </summary>
        [Test]
        public void TestAdd()
        {
            Calculator calculator = new Calculator();
            int result = calculator.ExecuteOperation("Add", 3, 5);
            Assert.AreEqual(8, result, "Addition method test failed.");
        }

        /// <summary>
        /// Tests the Add method with negative numbers.
        /// </summary>
        [Test]
        public void TestAddWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();
            int result = calculator.ExecuteOperation("Add", -3, -5);
            Assert.AreEqual(-8, result, "Addition method with negative numbers test failed.");
        }

        /// <summary>
        /// Tests the Subtract method.
        /// </summary>
        [Test]
        public void TestSubtract()
        {
            Calculator calculator = new Calculator();
            int result = calculator.ExecuteOperation("Subtract", 5, 3);
            Assert.AreEqual(2, result, "Subtract method test failed.");
        }

        /// <summary>
        /// Tests the Subtract method with negative numbers.
        /// </summary>
        [Test]
        public void TestSubtractWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();
            int result = calculator.ExecuteOperation("Subtract", -5, -3);
            Assert.AreEqual(-2, result, "Subtract method with negative numbers test failed.");
        }

        /// <summary>
        /// Tests the Divide method.
        /// </summary>
        [Test]
        public void TestDivide()
        {
            Calculator calculator = new Calculator();
            int result = calculator.ExecuteOperation("Divide", 10, 2);
            Assert.AreEqual(5, result, "Divide method test failed.");
        }

        /// <summary>
        /// Tests the Divide method with zero as the divisor.
        /// </summary>
        [Test]
        public void TestDivideByZero()
        {
            Calculator calculator = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calculator.ExecuteOperation("Divide", 6, 0));
        }

        /// <summary>
        /// Tests the Multiply method.
        /// </summary>
        [Test]
        public void TestMult()
        {
            Calculator calculator = new Calculator();
            int result = calculator.ExecuteOperation("Mult", 5, 3);
            Assert.AreEqual(15, result, "Mult method test failed.");
        }

        /// <summary>
        /// Tests the Multiply method with negative numbers.
        /// </summary>
        [Test]
        public void TestMultWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();
            int result = calculator.ExecuteOperation("Mult", -5, 3);
            Assert.AreEqual(-15, result, "Mult method with negative numbers test failed.");
        }

        /// <summary>
        /// Tests the Add method with zero.
        /// </summary>
        [Test]
        public void TestAddWithZero()
        {
            Calculator calculator = new Calculator();
            int result = calculator.ExecuteOperation("Add", 0, 5);
            Assert.AreEqual(5, result, "Addition method with zero test failed.");
        }

        /// <summary>
        /// Tests the Subtract method resulting in zero.
        /// </summary>
        [Test]
        public void TestSubtractToZero()
        {
            Calculator calculator = new Calculator();
            int result = calculator.ExecuteOperation("Subtract", 5, 5);
            Assert.AreEqual(0, result, "Subtract method to zero test failed.");
        }

        /// <summary>
        /// Tests the Divide method by one.
        /// </summary>
        [Test]
        public void TestDivideByOne()
        {
            Calculator calculator = new Calculator();
            int result = calculator.ExecuteOperation("Divide", 10, 1);
            Assert.AreEqual(10, result, "Divide method by one test failed.");
        }

        /// <summary>
        /// Tests the Multiply method with zero.
        /// </summary>
        [Test]
        public void TestMultByZero()
        {
            Calculator calculator = new Calculator();
            int result = calculator.ExecuteOperation("Mult", 5, 0);
            Assert.AreEqual(0, result, "Mult method by zero test failed.");
        }
    }
}