namespace TestRunner.Interfaces
{
    public interface ITestsRunner
    {
        ITestsSummary RunTests(string assemblyPath);
    }
}