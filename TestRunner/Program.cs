namespace TestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the path to the test assembly.");
                return;
            }

            string assemblyPath = args[0];
            TestRunner testRunner = new TestRunner();
            testRunner.RunTests(assemblyPath);

            TestSummary summary = testRunner.GetSummary();
            ConsoleReporter.PrintSummary(summary);
        }
    }
}
