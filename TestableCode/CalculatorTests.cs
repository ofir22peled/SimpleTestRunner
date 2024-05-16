using System;
using TestRunner; // Reference the TestAttribute from TestRunner

namespace TestableCode
{
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
        public void TestSubtract()
        {
            Calculator calculator = new Calculator();
            int result = calculator.Subtract(5, 3);
            Assert.AreEqual(2, result, "Subtract method test failed.");
        }

        [Test]
        public void TestDivide()
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
    }
}
