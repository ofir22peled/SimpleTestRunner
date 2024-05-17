using TestRunner.Arguments;
using TestRunner.Interfaces;
using TestRunner.Reporters;

namespace TestRunner
{
    /// <summary>
    /// Handles command line arguments for the test runner.
    /// </summary>
    public class ArgumentHandler : IArgumentHandler
    {
        private readonly ArgumentScanner _argumentScanner;
        private readonly ReporterFactory _reporterFactory;

        public ArgumentHandler()
        {
            _argumentScanner = new ArgumentScanner();
            _reporterFactory = new ReporterFactory();
        }

        public RunArguments ParseArguments(string[] args)
        {
            var (isValid, assemblyPath, outputType, outputPath) = _argumentScanner.ScanArguments(args);
            if (!isValid)
            {
                return GetMissingParametersResult();
            }

            if (assemblyPath == null)
            {
                return GetInvalidFilePathResult(args[0]);
            }

            IReporter reporter = _reporterFactory.CreateReporter(outputType, outputPath);
            if (reporter == null)
            {
                return new RunArguments(success: false, new ReporterConsole(), null);
            }

            return new RunArguments(success: true, reporter, assemblyPath);
        }

        private static RunArguments GetInvalidFilePathResult(string assemblyPath)
        {
            IReporter reporter = new ReporterConsole();
            reporter.PrintError($"Assembly file not found: {assemblyPath}");
            return new RunArguments(success: false, reporter, null);
        }

        private static RunArguments GetMissingParametersResult()
        {
            IReporter reporter = new ReporterConsole();
            reporter.PrintMessage("Usage: TestsRunner <path_to_test_assembly> <output_type> [<output_path>]");
            reporter.PrintMessage("output_type: console or file");
            reporter.PrintMessage("If output_type is file, provide <output_path> as the third argument.");
            return new RunArguments(success: false, reporter, null);
        }
    }
}