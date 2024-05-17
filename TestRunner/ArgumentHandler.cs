using TestRunner.Interfaces;
using TestRunner.Reporters;

namespace TestRunner
{
    /// <summary>
    /// Handles command line arguments for the test runner.
    /// </summary>
    public class ArgumentHandler : IArgumentHandler
    {
        public RunArguments ParseArguments(string[] args)
        {
            if (args.Length < 2)
            {
                return GetMissingParametersResult();
            }

            string assemblyPath = args[0];

            if (!File.Exists(assemblyPath))
            {
                return GetInvalidFilePathResult(assemblyPath);
            }
            
            IReporter tempReporter;
            string outputType = args[1];

            if (outputType.Equals("console", StringComparison.OrdinalIgnoreCase))
            {
                tempReporter = new ReporterConsole();
            }
            else if (outputType.Equals("file", StringComparison.OrdinalIgnoreCase))
            {
                if (args.Length < 3)
                {
                    tempReporter = new ReporterConsole();
                    tempReporter.PrintError("Please provide the output file path.");

                    return new RunArguments(success: false, tempReporter, assemblyPath: null);
                }

                string outputPath = args[2];
                tempReporter = new ReporterFile(outputPath);
            }
            else
            {
                tempReporter = new ReporterConsole();
                tempReporter.PrintError("Invalid output type. Use 'console' or 'file'.");

                return new RunArguments(success: false, tempReporter, assemblyPath: null);
            }

            return new RunArguments(success: true, tempReporter, assemblyPath);
        }

        private static RunArguments GetInvalidFilePathResult(string assemblyPath)
        {
            IReporter tempReporter = new ReporterConsole();
            tempReporter.PrintError($"Assembly file not found: {assemblyPath}");

            return new RunArguments(success: false, tempReporter, assemblyPath: null);
        }

        private RunArguments GetMissingParametersResult()
        {
            IReporter tempReporter = new ReporterConsole();
            tempReporter.PrintMessage("Usage: TestsRunner <path_to_test_assembly> <output_type> [<output_path>]");
            tempReporter.PrintMessage("output_type: console or file");
            tempReporter.PrintMessage("If output_type is file, provide <output_path> as the third argument.");

            return new RunArguments(success: false, tempReporter, assemblyPath: null);
        }
    }
}