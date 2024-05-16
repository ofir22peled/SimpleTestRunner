namespace TestRunner
{
    /// <summary>
    /// Collects and summarizes the results of test executions.
    /// </summary>
    public class TestSummary
    {
        public int TotalTests { get; private set; }
        public int PassedTests { get; private set; }
        public int FailedTests { get; private set; }
        public List<string> PassedTestNames { get; private set; }
        public List<string> FailedTestNames { get; private set; }

        public TestSummary()
        {
            TotalTests = 0;
            PassedTests = 0;
            FailedTests = 0;
            PassedTestNames = new List<string>();
            FailedTestNames = new List<string>();
        }

        /// <summary>
        /// Adds the result of a test execution.
        /// </summary>
        /// <param name="passed">Indicates whether the test passed.</param>
        /// <param name="testName">The name of the test.</param>
        public void AddResult(bool passed, string testName)
        {
            TotalTests++;
            if (passed)
            {
                PassedTests++;
                PassedTestNames.Add(testName);
            }
            else
            {
                FailedTests++;
                FailedTestNames.Add(testName);
            }
        }
    }
}