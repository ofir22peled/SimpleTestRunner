using TestRunner.Interfaces;

namespace TestRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            IArgumentHandler argumentHandler = new ArgumentHandler();
            RunArguments runArgument = argumentHandler.ParseArguments(args);

            if (runArgument.Success)
            {
                IReporter reporter = runArgument.Reporter;
                TestsRunner testRunner = new TestsRunner(reporter, new TestsSummary(), new TestsFinder(reporter));
                ITestsSummary summary = testRunner.RunTests(runArgument.AssemblyPath);

                runArgument.Reporter.PrintSummary(summary);
            }
        }
    }
}