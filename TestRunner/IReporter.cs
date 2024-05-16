namespace TestRunner
{
    /// <summary>
    /// Defines methods for reporting test results.
    /// </summary>
    public interface IReporter
    {
        /// <summary>
        /// Reports a passed test.
        /// </summary>
        /// <param name="testName">The name of the test that passed.</param>
        void TestPassed(string testName);

        /// <summary>
        /// Reports a failed test.
        /// </summary>
        /// <param name="testName">The name of the test that failed.</param>
        /// <param name="reason">The reason the test failed.</param>
        void TestFailed(string testName, string reason);

        /// <summary>
        /// Reports a failure to load an assembly.
        /// </summary>
        /// <param name="assemblyFile">The path of the assembly file that failed to load.</param>
        /// <param name="reason">The reason the assembly failed to load.</param>
        void AssemblyLoadFailed(string assemblyFile, string reason);

        /// <summary>
        /// Reports a failure to create an instance of a test class.
        /// </summary>
        /// <param name="className">The name of the class that could not be instantiated.</param>
        void InstanceCreationFailed(string className);

        /// <summary>
        /// Prints a summary of the test results.
        /// </summary>
        /// <param name="summary">The test summary to print.</param>
        void PrintSummary(TestSummary summary);

        /// <summary>
        /// Prints a general message.
        /// </summary>
        /// <param name="message">The message to print.</param>
        void PrintMessage(string message);

        /// <summary>
        /// Prints an error message.
        /// </summary>
        /// <param name="error">The error message to print.</param>
        void PrintError(string error);
    }
}