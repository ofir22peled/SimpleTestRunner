using System.Collections.Generic;

namespace TestRunner
{
    public class TestSummary
    {
        public int TotalTests { get; private set; }
        public int PassedTests { get; private set; }
        public int FailedTests { get; private set; }
        public List<string> FailedTestNames { get; private set; }

        public TestSummary()
        {
            TotalTests = 0;
            PassedTests = 0;
            FailedTests = 0;
            FailedTestNames = new List<string>();
        }

        public void AddResult(bool passed, string testName)
        {
            TotalTests++;
            if (passed)
            {
                PassedTests++;
            }
            else
            {
                FailedTests++;
                FailedTestNames.Add(testName);
            }
        }
    }
}
