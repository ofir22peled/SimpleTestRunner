using TestRunner.Interfaces;

namespace TestRunner
{
    public class RunArguments
    {
        private bool success;
        private IReporter reporter;
        private string assemblyPath;

        public RunArguments(bool success, IReporter reporter, string assemblyPath)
        {
            this.success = success;
            this.reporter = reporter;
            this.assemblyPath = assemblyPath;
        }

        public bool Success
        {
            get { return success; }
            set { success = value; }
        }

        public IReporter Reporter
        {
            get { return reporter; }
            set { reporter = value; }
        }

        public string AssemblyPath
        {
            get { return assemblyPath; }
            set { assemblyPath = value; }
        }
    }
}