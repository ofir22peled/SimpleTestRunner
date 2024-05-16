using System.Reflection;
using TestableCode;

namespace TestRunner
{
    public class TestRunner
    {
        private int totalTests;
        private int passedTests;
        private int failedTests;
        private List<string> failedTestNames;

        // Constructor
        public TestRunner()
        {
            totalTests = 0;
            passedTests = 0;
            failedTests = 0;
            failedTestNames = new List<string>();
        }

        public void RunTests()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string[] dllFiles = Directory.GetFiles(currentDirectory, "*.dll");

            // Run tests from all dll files in the directory
            foreach (string dllFile in dllFiles)
            {
                RunTestsInAssembly(dllFile);
            }

            PrintSummary();
        }

        // Run the tests in a specific assembly file
        private void RunTestsInAssembly(string assemblyFile)
        {
            try
            {
                Assembly testAssembly = Assembly.LoadFrom(assemblyFile);

                foreach (Type type in testAssembly.GetTypes())
                {
                    foreach (MethodInfo method in type.GetMethods())
                    {
                        if (method.GetCustomAttributes(typeof(TestAttribute), inherit: false).Any())
                        {
                            totalTests++;
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
                failedTests++;
                failedTestNames.Add(method.Name);
                return;
            }

            try
            {
                method.Invoke(instance, parameters: null);
                Console.WriteLine($"Test Passed: {method.Name}");
                passedTests++;
            }
            catch (TargetInvocationException ex)
            {
                Console.WriteLine($"Test Failed: {method.Name}. Reason: {ex.InnerException?.Message ?? ex.Message}");
                failedTests++;
                failedTestNames.Add(method.Name);
            }
        }

        private void PrintSummary()
        {
            Console.WriteLine();
            Console.WriteLine("----- Test Summary -----");
            Console.WriteLine($"Total Tests: {totalTests}");
            Console.WriteLine($"Tests Passed: {passedTests}");
            Console.WriteLine($"Tests Failed: {failedTests}");
            Console.WriteLine();

            if (failedTests > 0)
            {
                Console.WriteLine("Failed Tests:");
                foreach (var testName in failedTestNames)
                {
                    Console.WriteLine($"- {testName}");
                }
                Console.WriteLine();
            }
        }
    }
}