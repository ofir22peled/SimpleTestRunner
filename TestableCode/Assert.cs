namespace TestableCode
{
    /// <summary>
    /// 
    /// </summary>
    public static class Assert
    {
        // Checks if two values are equal
        public static void AreEqual<T>(T expected, T actual, string message = "")
        {
            if (!EqualityComparer<T>.Default.Equals(expected, actual))
            {
                throw new AssertionException($"Assertion Failed: {message}. Expected: {expected}, Actual: {actual}");
            }
        }

        // Checks if a condition is true
        public static void IsTrue(bool condition, string message = "")
        {
            if (!condition)
            {
                throw new AssertionException($"Assertion Failed: {message}");
            }
        }

        // Checks if a specific type of exception is thrown
        public static void Throws<T>(Action action) where T : Exception
        {
            try
            {
                // Attempt to execute the action that is expected to throw an exception.
                action();

                // If no exception is thrown, this line is reached and we throw an AssertionException
                // because we expected an exception of type T but none was thrown.
                throw new AssertionException($"Expected exception of type {typeof(T).Name} but no exception was thrown.");
            }
            catch (T)
            {
                // This block catches the specific exception type T.
                // If an exception of type T is thrown, it is the expected outcome, so we do nothing.
            }
            catch (Exception ex)
            {
                // This block catches any other type of exception.
                // If an exception is thrown that is not of type T, we throw an AssertionException
                // indicating that the wrong type of exception was thrown.
                throw new AssertionException($"Expected exception of type {typeof(T).Name} but got exception of type {ex.GetType().Name}.", ex);
            }
        }
    }
}