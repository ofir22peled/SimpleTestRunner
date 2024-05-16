namespace TestRunner
{
    public static class Assert
    {
        public static void AreEqual<T>(T expected, T actual, string message = "")
        {
            if (!EqualityComparer<T>.Default.Equals(expected, actual))
            {
                throw new AssertionException($"Assertion Failed: {message}. Expected: {expected}, Actual: {actual}");
            }
        }

        public static void IsTrue(bool condition, string message = "")
        {
            if (!condition)
            {
                throw new AssertionException($"Assertion Failed: {message}");
            }
        }

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