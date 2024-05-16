namespace TestRunner
{
    public interface IReporter
    {
        void TestPassed(string testName);
        void TestFailed(string testName, string reason);
        void AssemblyLoadFailed(string assemblyFile, string reason);
        void InstanceCreationFailed(string className);
        void PrintSummary(TestSummary summary);
        void PrintMessage(string message);
        void PrintError(string error);
    }
}