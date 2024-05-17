namespace TestRunner
{
    public class ArgumentScanner
    {
        public (bool IsValid, string AssemblyPath, string OutputType, string OutputPath) ScanArguments(string[] args)
        {
            if (args.Length < 2)
            {
                return (false, null, null, null);
            }

            string assemblyPath = args[0];
            if (!File.Exists(assemblyPath))
            {
                return (false, assemblyPath, null, null);
            }

            string outputType = args[1].ToLowerInvariant();
            string outputPath = args.Length >= 3 ? args[2] : null;

            return (true, assemblyPath, outputType, outputPath);
        }
    }
}
