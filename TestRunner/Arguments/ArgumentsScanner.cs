namespace TestRunner
{
    public class ArgumentScanner
    {
        public (bool IsValid, string AssemblyPath, string OutputType, string OutputPath) ScanArguments(string[] args)
        {
            string outputType = null;
            string outputPath = null;
            string assemblyPath = args[0];
            bool isValidArgs = false;

            if (args.Length >= 2 && File.Exists(assemblyPath))
            {
                outputType = args[1].ToLowerInvariant();
                outputPath = args.Length >= 3 ? args[2] : null;
                isValidArgs = true;
            }

            return (isValidArgs, assemblyPath, outputType, outputPath);
        }
    }
}
