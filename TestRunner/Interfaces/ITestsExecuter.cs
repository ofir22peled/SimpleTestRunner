using System.Reflection;

namespace TestRunner.Interfaces
{
    public interface ITestsExecuter
    {
        void ExecuteTests(IReadOnlyCollection<MethodInfo> methodInfos);
    }
}