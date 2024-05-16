using System;

namespace TestRunner
{
    public class ConsoleReporter : IReporter
    {
        public void TestPassed(string testName)
        {
            Console.WriteLine($"Test Passed: {testName}");
        }

        public void TestFailed(string testName, string reason)
        {
            Console.WriteLine($"Test Failed: {testName}. Reason: {reason}");
        }

        public void AssemblyLoadFailed(string assemblyFile, string reason)
        {
            Console.WriteLine($"Failed to load assembly: {assemblyFile}. Reason: {reason}");
        }

        public void InstanceCreationFailed(string className)
        {
            Console.WriteLine($"Failed to create an instance of the test class: {className}");
        }

        public void PrintSummary(TestSummary summary)
        {
            Console.WriteLine();
            Console.WriteLine("----- Test Summary -----");
            Console.WriteLine($"Total Tests: {summary.TotalTests}");
            Console.WriteLine($"Tests Passed: {summary.PassedTests}");
            Console.WriteLine($"Tests Failed: {summary.FailedTests}");
            Console.WriteLine();

            if (summary.PassedTests > 0)
            {
                Console.WriteLine("Passed Tests:");
                foreach (var testName in summary.PassedTestNames)
                {
                    Console.WriteLine($"- {testName}");
                }
                Console.WriteLine();
            }

            if (summary.FailedTests > 0)
            {
                Console.WriteLine("Failed Tests:");
                foreach (var testName in summary.FailedTestNames)
                {
                    Console.WriteLine($"- {testName}");
                }
                Console.WriteLine();
            }
        }

        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintError(string error)
        {
            Console.WriteLine(error);
        }
    }
}