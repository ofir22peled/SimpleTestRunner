using System.Reflection;

namespace TestRunner.Interfaces
{
    public interface ITestsFinder
    {
        IReadOnlyCollection<MethodInfo> FindTests(string assemblyFilePath);
    }
}