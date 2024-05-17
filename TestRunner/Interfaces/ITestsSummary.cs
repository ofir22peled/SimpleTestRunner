namespace TestRunner.Interfaces
{
    public interface ITestsSummary
    {
        IReadOnlyCollection<string> FailedTestNames { get; }
        IReadOnlyCollection<string> PassedTestNames { get; }
        int FailedTests { get; }
        int PassedTests { get; }
        int TotalTests { get; }
        double AverageTestDuration { get; }
        TimeSpan TotalTestDuration { get; }

        void AddFailureResult(string testName, double duration);
        void AddSuccessResult(string testName, double duration);
    }
}