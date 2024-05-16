using System;
using System.IO;

namespace TestRunner
{
    public static class ArgumentHandler
    {
        public static (bool success, IReporter reporter, string assemblyPath) ParseArguments(string[] args)
        {
            IReporter tempReporter;

            if (args.Length < 2)
            {
                tempReporter = new ConsoleReporter();
                tempReporter.PrintMessage("Usage: TestRunner <path_to_test_assembly> <output_type> [<output_path>]");
                tempReporter.PrintMessage("output_type: console or file");
                tempReporter.PrintMessage("If output_type is file, provide <output_path> as the third argument.");
                return (false, tempReporter, null);
            }

            string assemblyPath = args[0];
            string outputType = args[1];

            if (!File.Exists(assemblyPath))
            {
                tempReporter = new ConsoleReporter();
                tempReporter.PrintError($"Assembly file not found: {assemblyPath}");
                return (false, tempReporter, null);
            }

            if (outputType.Equals("console", StringComparison.OrdinalIgnoreCase))
            {
                tempReporter = new ConsoleReporter();
            }
            else if (outputType.Equals("file", StringComparison.OrdinalIgnoreCase))
            {
                if (args.Length < 3)
                {
                    tempReporter = new ConsoleReporter();
                    tempReporter.PrintError("Please provide the output file path.");
                    return (false, tempReporter, null);
                }
                string outputPath = args[2];
                tempReporter = new FileReporter(outputPath);
            }
            else
            {
                tempReporter = new ConsoleReporter();
                tempReporter.PrintError("Invalid output type. Use 'console' or 'file'.");
                return (false, tempReporter, null);
            }

            return (true, tempReporter, assemblyPath);
        }
    }
}