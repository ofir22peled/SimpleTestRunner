using TestRunner.Assertions;

namespace TestableCode
{
    /// <summary>
    /// Tests for the Calculator class.
    /// </summary>
    public class CalculatorTests
    {
        [Test]
        public void TestAdd()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Add(3, 5);
            Assert.AreEqual(8, result, "Add method test failed.");
        }

        [Test]
        public void TestAddWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Add(-3, -5);
            Assert.AreEqual(-8, result, "Add method with negative numbers test failed.");
        }

        [Test]
        public void TestSubtract()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Subtract(5, 3);
            Assert.AreEqual(2, result, "Subtract method test failed.");
        }

        [Test]
        public void TestSubtractWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Subtract(-5, -3);
            Assert.AreEqual(-2, result, "Subtract method with negative numbers test failed.");
        }

        [Test]
        public void TestDivide()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Divide(10, 2);
            Assert.AreEqual(5, result, "Divide method test failed.");
        }

        [Test]
        public void TestDivideByZero()
        {
            Calculator calculator = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(6, 0));
        }

        [Test]
        public void TestMult()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Mult(5, 3);
            Assert.AreEqual(15, result, "Mult method test failed.");
        }

        [Test]
        public void TestMultWithNegativeNumbers()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Mult(-5, 3);
            Assert.AreEqual(-15, result, "Mult method with negative numbers test failed.");
        }

        [Test]
        public void TestAddWithZero()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Add(0, 5);
            Assert.AreEqual(5, result, "Add method with zero test failed.");
        }

        [Test]
        public void TestSubtractToZero()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Subtract(5, 5);
            Assert.AreEqual(0, result, "Subtract method to zero test failed.");
        }

        [Test]
        public void TestDivideByOne()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Divide(10, 1);
            Assert.AreEqual(10, result, "Divide method by one test failed.");
        }

        [Test]
        public void TestMultByZero()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Mult(5, 0);
            Assert.AreEqual(0, result, "Mult method by zero test failed.");
        }
    }
}