namespace TestRunner.Interfaces
{
    public interface ITestsSummary
    {
        IReadOnlyCollection<string> FailedTestNames { get; }
        IReadOnlyCollection<string> PassedTestNames { get; }
        int FailedTests { get; }
        int PassedTests { get; }
        int TotalTests { get; }

        void AddFailureResult(string testName);
        void AddSuccessResult(string testName);
    }
}