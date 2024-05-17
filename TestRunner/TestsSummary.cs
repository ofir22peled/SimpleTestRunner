using TestRunner.Interfaces;

namespace TestRunner
{
    /// <summary>
    /// Collects and summarizes the results of test executions.
    /// </summary>
    public class TestsSummary : ITestsSummary
    {
        public int TotalTests { get; private set; }
        public int PassedTests { get; private set; }
        public int FailedTests { get; private set; }
        public double AverageTestDuration => _testDurations.Any() ? _testDurations.Average() : 0;
        public TimeSpan TotalTestDuration => TimeSpan.FromMilliseconds(_testDurations.Sum());

        public IReadOnlyCollection<string> PassedTestNames => _passedTestNames;
        private List<string> _passedTestNames;
        public IReadOnlyCollection<string> FailedTestNames => _failedTestNames;
        private List<string> _failedTestNames;

        private List<double> _testDurations;

        /// <summary>
        /// ctor
        /// </summary>
        public TestsSummary()
        {
            TotalTests = 0;
            PassedTests = 0;
            FailedTests = 0;
            _passedTestNames = new List<string>();
            _failedTestNames = new List<string>();
            _testDurations = new List<double>();
        }

        /// <summary>
        /// Adds the result of a successful test execution.
        /// </summary>
        /// <param name="testName">The name of the test.</param>
        /// <param name="duration">The duration of the test execution in milliseconds.</param>
        public void AddSuccessResult(string testName, double duration)
        {
            TotalTests++;
            PassedTests++;
            _passedTestNames.Add(testName);
            _testDurations.Add(duration);
        }

        /// <summary>
        /// Adds the result of a failed test execution.
        /// </summary>
        /// <param name="testName">The name of the test.</param>
        /// <param name="duration">The duration of the test execution in milliseconds.</param>
        public void AddFailureResult(string testName, double duration)
        {
            TotalTests++;
            FailedTests++;
            _failedTestNames.Add(testName);
            _testDurations.Add(duration);
        }
    }
}