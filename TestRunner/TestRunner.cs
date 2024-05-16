using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TestRunner
{
    public class TestRunner
    {
        private readonly TestSummary _summary;

        public TestRunner()
        {
            _summary = new TestSummary();
        }

        public void RunTests(string assemblyPath)
        {
            if (!File.Exists(assemblyPath))
            {
                Console.WriteLine($"Assembly file not found: {assemblyPath}");
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
                Console.WriteLine($"Failed to load assembly: {assemblyFile}. Reason: {ex.Message}");
            }
        }

        private void ExecuteTest(MethodInfo method, object instance)
        {
            if (instance == null)
            {
                Console.WriteLine($"Failed to create an instance of the test class: {method.DeclaringType.Name}");
                _summary.AddResult(false, method.Name);
                return;
            }

            try
            {
                method.Invoke(instance, null);
                Console.WriteLine($"Test Passed: {method.Name}");
                _summary.AddResult(true, method.Name);
            }
            catch (TargetInvocationException ex)
            {
                Console.WriteLine($"Test Failed: {method.Name}. Reason: {ex.InnerException?.Message ?? ex.Message}");
                _summary.AddResult(false, method.Name);
            }
        }

        public TestSummary GetSummary()
        {
            return _summary;
        }
    }
}
