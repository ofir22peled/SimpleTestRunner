using System;

namespace TestRunner
{
    /// <summary>
    /// Attribute to mark methods as test methods.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TestAttribute : Attribute
    {
    }
}