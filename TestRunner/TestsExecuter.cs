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

        public void ExecuteTests(IReadOnlyCollection<MethodInfo> methodInfos)
        {
            foreach (MethodInfo test in methodInfos)
            {
                // Create an instance of the type containing the test method
                object instance = Activator.CreateInstance(test.DeclaringType);

                ExecuteTest(test, instance);
            }
        }

        private void ExecuteTest(MethodInfo method, object instance)
        {
            if (instance == null)
            {
                _reporter.InstanceCreationFailed(method.DeclaringType.Name);
                _summary.AddFailureResult(method.Name, 0);
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            try
            {
                stopwatch.Start();
                // Invoke the test method
                method.Invoke(instance, null);
                stopwatch.Stop();

                _reporter.TestPassed(method.Name);
                _summary.AddSuccessResult(method.Name, stopwatch.Elapsed.TotalMilliseconds);
            }
            catch (TargetInvocationException ex)
            {
                stopwatch.Stop();
                // Catch exceptions thrown by the test method
                _reporter.TestFailed(method.Name, ex.InnerException?.Message ?? ex.Message);
                _summary.AddFailureResult(method.Name, stopwatch.Elapsed.TotalMilliseconds);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                // Catch any other exceptions that may occur
                _reporter.TestFailed(method.Name, ex.Message);
                _summary.AddFailureResult(method.Name, stopwatch.Elapsed.TotalMilliseconds);
            }
        }
    }
}