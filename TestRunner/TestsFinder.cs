using System.Reflection;
using TestRunner.Attributes;
using TestRunner.Interfaces;

namespace TestRunner
{
    public class TestsFinder : ITestsFinder
    {
        private readonly IReporter _reporter;

        public TestsFinder(IReporter reporter)
        {
            _reporter = reporter;
        }

        public IReadOnlyCollection<MethodInfo> FindTests(string assemblyFilePath)
        {
            try
            {
                Assembly testAssembly = Assembly.LoadFrom(assemblyFilePath);

                //List<MethodInfo> methodInfos1 = new List<MethodInfo>();

                //foreach (Type type in testAssembly.GetTypes())
                //{
                //    foreach (MethodInfo method in type.GetMethods())
                //    {
                //        if (method.GetCustomAttributes(typeof(TestAttribute), inherit: false).Any())
                //        {
                //            methodInfos1.Add(method);
                //        }
                //    }
                //}

                List<MethodInfo> methodInfos = testAssembly.GetTypes()
                    .SelectMany(type => type.GetMethods())
                    .Where(method => method.GetCustomAttributes(typeof(TestAttribute), inherit: false).Any())
                    .ToList();

                return methodInfos;
            }
            catch (Exception ex)
            {
                _reporter.AssemblyLoadFailed(assemblyFilePath, ex.Message);
                return Array.Empty<MethodInfo>();
            }
        }

    }
}