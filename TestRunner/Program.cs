using TestRunner.Arguments;
using TestRunner.Interfaces;
using TestRunner.Tests;

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
                ITestsSummary summary = new TestsSummary();
                ITestsFinder testsFinder = new TestsFinder(reporter);
                ITestsExecuter testsExecuter = new TestsExecuter(reporter, summary);

                TestsRunner testRunner = new TestsRunner(reporter, summary, testsFinder, testsExecuter);
                summary = testRunner.RunTests(runArgument.AssemblyPath);

                runArgument.Reporter.PrintSummary(summary);
            }
        }
    }
}