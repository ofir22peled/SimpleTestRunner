namespace TestableCode.Interfaces
{
    public interface ICalculatorOperation
    {
        string OperationName { get; }
        int Execute(int a, int b);
    }
}