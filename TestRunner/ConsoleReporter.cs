namespace TestRunner
{
    public static class ConsoleReporter
    {
        public static void PrintSummary(TestSummary summary)
        {
            Console.WriteLine();
            Console.WriteLine("----- Test Summary -----");
            Console.WriteLine($"Total Tests: {summary.TotalTests}");
            Console.WriteLine($"Tests Passed: {summary.PassedTests}");
            Console.WriteLine($"Tests Failed: {summary.FailedTests}");
            Console.WriteLine();

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
    }
}