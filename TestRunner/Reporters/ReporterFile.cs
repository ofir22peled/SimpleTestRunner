using System.Text;
using TestRunner.Interfaces;

namespace TestRunner.Reporters
{
    /// <summary>
    /// Reports test results to a file.
    /// </summary>
    public class ReporterFile : IReporter
    {
        private readonly string _filePath;
        private readonly StringBuilder _content;

        public ReporterFile(string filePath)
        {
            _filePath = filePath;
            _content = new StringBuilder();
        }

        public void TestPassed(string testName)
        {
            _content.AppendLine($"Test Passed: {testName}");
        }

        public void TestFailed(string testName, string reason)
        {
            _content.AppendLine($"Test Failed: {testName}. Reason: {reason}");
        }

        public void AssemblyLoadFailed(string assemblyFile, string reason)
        {
            _content.AppendLine($"Failed to load assembly: {assemblyFile}. Reason: {reason}");
        }

        public void InstanceCreationFailed(string className)
        {
            _content.AppendLine($"Failed to create an instance of the test class: {className}");
        }

        public void PrintSummary(ITestsSummary summary)
        {
            _content.AppendLine();
            _content.AppendLine("----- Test Summary -----");
            _content.AppendLine($"Total Tests: {summary.TotalTests}");
            _content.AppendLine($"Tests Passed: {summary.PassedTests}");
            _content.AppendLine($"Tests Failed: {summary.FailedTests}");
            _content.AppendLine();

            if (summary.PassedTests > 0)
            {
                _content.AppendLine("Passed Tests:");
                foreach (var testName in summary.PassedTestNames)
                {
                    _content.AppendLine($"- {testName}");
                }
                _content.AppendLine();
            }

            if (summary.FailedTests > 0)
            {
                _content.AppendLine("Failed Tests:");
                foreach (var testName in summary.FailedTestNames)
                {
                    _content.AppendLine($"- {testName}");
                }
                _content.AppendLine();
            }

            File.WriteAllText(_filePath, _content.ToString());
        }

        public void PrintMessage(string message)
        {
            _content.AppendLine(message);
        }

        public void PrintError(string error)
        {
            _content.AppendLine(error);
        }
    }
}