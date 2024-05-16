namespace TestRunner
{
    /// <summary>
    /// Provides static methods for making assertions in tests.
    /// </summary>
    public static class Assert
    {
        /// <summary>
        /// Asserts that two values are equal.
        /// </summary>
        /// <typeparam name="T">The type of the values to compare.</typeparam>
        /// <param name="expected">The expected value.</param>
        /// <param name="actual">The actual value.</param>
        /// <param name="message">The message to include in the exception if the assertion fails.</param>
        public static void AreEqual<T>(T expected, T actual, string message = "")
        {
            if (!EqualityComparer<T>.Default.Equals(expected, actual))
            {
                throw new AssertionException($"Assertion Failed: {message}. Expected: {expected}, Actual: {actual}");
            }
        }

        /// <summary>
        /// Asserts that a condition is true.
        /// </summary>
        /// <param name="condition">The condition to check.</param>
        /// <param name="message">The message to include in the exception if the assertion fails.</param>
        public static void IsTrue(bool condition, string message = "")
        {
            if (!condition)
            {
                throw new AssertionException($"Assertion Failed: {message}");
            }
        }

        /// <summary>
        /// Asserts that a specified exception is thrown.
        /// </summary>
        /// <typeparam name="T">The type of exception expected to be thrown.</typeparam>
        /// <param name="action">The action that is expected to throw the exception.</param>
        public static void Throws<T>(Action action) where T : Exception
        {
            try
            {
                action();
                throw new AssertionException($"Expected exception of type {typeof(T).Name} but no exception was thrown.");
            }
            catch (T)
            {
                // Expected exception
            }
            catch (Exception ex)
            {
                throw new AssertionException($"Expected exception of type {typeof(T).Name} but got exception of type {ex.GetType().Name}.", ex);
            }
        }
    }
}