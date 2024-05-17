namespace TestableCode.Interfaces
{
    public interface ICalculatorTests
    {
        void TestAdd();
        void TestAddWithNegativeNumbers();
        void TestAddWithZero();
        void TestDivide();
        void TestDivideByOne();
        void TestDivideByZero();
        void TestMult();
        void TestMultByZero();
        void TestMultWithNegativeNumbers();
        void TestSubtract();
        void TestSubtractToZero();
        void TestSubtractWithNegativeNumbers();
    }
}