namespace TestRunner.Assertions
{
    /// <summary>
    /// Custom exception for assertion failures.
    /// </summary>
    public class AssertionException : Exception
    {
        public AssertionException() { }

        public AssertionException(string message)
            : base(message) { }

        public AssertionException(string message, Exception inner)
            : base(message, inner) { }
    }
}