namespace TestRunner.Interfaces
{
    public interface IArgumentHandler
    {
        RunArguments ParseArguments(string[] args);
    }
}