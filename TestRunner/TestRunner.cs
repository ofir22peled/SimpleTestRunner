using System.Reflection;

namespace TestRunner
{
    /// <summary>
    /// Runs tests and reports results.
    /// </summary>
    public class TestRunner
    {
        private readonly TestSummary _summary;
        private readonly IReporter _reporter;

        public TestRunner(IReporter reporter)
        {
            _summary = new TestSummary();
            _reporter = reporter;
        }

        /// <summary>
        /// Runs tests in the specified assembly.
        /// </summary>
        public void RunTests(string assemblyPath)
        {
            if (!File.Exists(assemblyPath))
            {
                _reporter.AssemblyLoadFailed(assemblyPath, "File not found");
                return;
            }

            RunTestsInAssembly(assemblyPath);
        }

        private void RunTestsInAssembly(string assemblyFile)
        {
            try
            {
                Assembly testAssembly = Assembly.LoadFrom(assemblyFile);

                foreach (Type type in testAssembly.GetTypes())
                {
                    foreach (MethodInfo method in type.GetMethods())
                    {
                        if (method.GetCustomAttributes(typeof(TestAttribute), false).Any())
                        {
                            ExecuteTest(method, Activator.CreateInstance(type));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _reporter.AssemblyLoadFailed(assemblyFile, ex.Message);
            }
        }

        private void ExecuteTest(MethodInfo method, object instance)
        {
            if (instance == null)
            {
                _reporter.InstanceCreationFailed(method.DeclaringType.Name);
                _summary.AddResult(false, method.Name);
                return;
            }

            try
            {
                method.Invoke(instance, null);
                _reporter.TestPassed(method.Name);
                _summary.AddResult(true, method.Name);
            }
            catch (TargetInvocationException ex)
            {
                _reporter.TestFailed(method.Name, ex.InnerException?.Message ?? ex.Message);
                _summary.AddResult(false, method.Name);
            }
        }

        /// <summary>
        /// Gets the summary of test results.
        /// </summary>
        public TestSummary GetSummary()
        {
            return _summary;
        }
    }
}