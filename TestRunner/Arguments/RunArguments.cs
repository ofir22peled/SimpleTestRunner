using TestRunner.Interfaces;

namespace TestRunner.Arguments
{
    public class RunArguments
    {
        public bool Success { get; }
        public IReporter Reporter { get; }
        public string AssemblyPath { get; }

        public RunArguments(bool success, IReporter reporter, string assemblyPath)
        {
            Success = success;
            Reporter = reporter;
            AssemblyPath = assemblyPath;
        }
    }
}