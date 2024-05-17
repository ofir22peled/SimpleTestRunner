using System.Diagnostics;
using System.Reflection;
using TestRunner.Interfaces;

namespace TestRunner
{
    public class TestsExecuter : ITestsExecuter
    {
        private readonly ITestsSummary _summary;
        private readonly IReporter _reporter;

        public TestsExecuter(IReporter reporter, ITestsSummary summary)
        {
            _summary = summary;
            _reporter = reporter;
        }

        /// <summary>
        /// Executes all test methods in the provided collection.
        /// </summary>
        /// <param name="methodInfos">A collection of MethodInfo objects representing the test methods to be executed.</param>
        public void ExecuteTests(IReadOnlyCollection<MethodInfo> methodInfos)
        {
            foreach (MethodInfo test in methodInfos)
            {
                // Create an instance of the type containing the test method
                object instance = Activator.CreateInstance(test.DeclaringType);

                // Execute the test method
                ExecuteTest(test, instance);
            }
        }

        /// <summary>
        /// Executes a single test method.
        /// </summary>
        /// <param name="method">The MethodInfo object representing the test method to be executed.</param>
        /// <param name="instance">An instance of the type containing the test method.</param>
        public void ExecuteTest(MethodInfo method, object instance)
        {
            if (instance == null)
            {
                // Report instance creation failure and record the test as failed
                _reporter.InstanceCreationFailed(method.DeclaringType.Name);
                _summary.AddFailureResult(method.Name, 0);
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            try
            {
                stopwatch.Start();
                method.Invoke(instance, null);
                stopwatch.Stop();

                // Report the test as passed and record the success result with duration
                _reporter.TestPassed(method.Name);
                _summary.AddSuccessResult(method.Name, stopwatch.Elapsed.TotalMilliseconds);
            }
            catch (TargetInvocationException ex)
            {
                stopwatch.Stop();

                // Report the test as failed and record the failure result with duration
                _reporter.TestFailed(method.Name, ex.InnerException?.Message ?? ex.Message);
                _summary.AddFailureResult(method.Name, stopwatch.Elapsed.TotalMilliseconds);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

                // Report any other exceptions as test failures and record the failure result with duration
                _reporter.TestFailed(method.Name, ex.Message);
                _summary.AddFailureResult(method.Name, stopwatch.Elapsed.TotalMilliseconds);
            }
        }
    }
}