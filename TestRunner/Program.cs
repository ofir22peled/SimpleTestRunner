namespace TestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            var (success, reporter, assemblyPath) = ArgumentHandler.ParseArguments(args);

            if (!success)
            {
                return;
            }

            TestRunner testRunner = new TestRunner(reporter);
            testRunner.RunTests(assemblyPath);

            TestSummary summary = testRunner.GetSummary();
            reporter.PrintSummary(summary);
        }
    }
}