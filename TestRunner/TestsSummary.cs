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
        public IReadOnlyCollection<string> PassedTestNames => _passedTestNames;
        private List<string> _passedTestNames;
        public IReadOnlyCollection<string> FailedTestNames => _failedTestNames;
        private List<string> _failedTestNames;

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
        }

        /// <summary>
        /// Adds the result of a test execution.
        /// </summary>
        /// <param name="testName">The name of the test.</param>
        public void AddSuccessResult(string testName)
        {
            TotalTests++;

            PassedTests++;
            _passedTestNames.Add(testName);
        }

        //TODO: DOC
        public void AddFailureResult(string testName)
        {
            TotalTests++;
            FailedTests++;
            _failedTestNames.Add(testName);
        }
    }
}