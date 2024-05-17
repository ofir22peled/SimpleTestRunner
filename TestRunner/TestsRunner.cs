using System.Reflection;
using TestRunner.Interfaces;

namespace TestRunner
{
    /// <summary>
    /// Runs tests and reports results.
    /// </summary>
    public class TestsRunner : ITestsRunner
    {
        private readonly ITestsSummary _summary;
        private readonly IReporter _reporter;
        private readonly ITestsFinder _testsFinder;
        private readonly ITestsExecuter _testsExecuter;

        public TestsRunner(IReporter reporter, ITestsSummary summary, ITestsFinder testsFinder, ITestsExecuter testsExecuter)
        {
            _summary = summary;
            _reporter = reporter;
            _testsFinder = testsFinder;
            _testsExecuter = testsExecuter;
        }

        /// <summary>
        /// Runs tests in the specified assembly.
        /// </summary>
        public ITestsSummary RunTests(string assemblyPath)
        {
            if (File.Exists(assemblyPath))
            {
                RunTestsInAssembly(assemblyPath);
            }
            else
            {
                _reporter.AssemblyLoadFailed(assemblyPath, "File not found");
            }

            return _summary;
        }

        private void RunTestsInAssembly(string assemblyFilePath)
        {
            try
            {
                IReadOnlyCollection<MethodInfo> methodInfos = _testsFinder.FindTests(assemblyFilePath);

                _testsExecuter.ExecuteTests(methodInfos);
            }
            catch (Exception ex)
            {
                _reporter.AssemblyLoadFailed(assemblyFilePath, ex.Message);
            }
        }
    }
}