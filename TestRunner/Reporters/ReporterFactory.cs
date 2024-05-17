using TestRunner.Interfaces;
using TestRunner.Reporters;

namespace TestRunner
{
    public class ReporterFactory
    {
        private const string ConsoleOutput = "console";
        private const string FileOutput = "file";

        public IReporter CreateReporter(string outputType, string outputPath)
        {
            return outputType switch
            {
                ConsoleOutput => new ReporterConsole(),
                FileOutput => CreateFileReporter(outputPath),
                _ => CreateInvalidReporter(),
            };
        }

        private IReporter CreateFileReporter(string outputPath)
        {
            if (string.IsNullOrWhiteSpace(outputPath))
            {
                IReporter reporter = new ReporterConsole();
                reporter.PrintError("Please provide the output file path.");
                return reporter;
            }

            return new ReporterFile(outputPath);
        }

        private IReporter CreateInvalidReporter()
        {
            IReporter reporter = new ReporterConsole();
            reporter.PrintError("Invalid output type. Use 'console' or 'file'.");
            return reporter;
        }
    }
}