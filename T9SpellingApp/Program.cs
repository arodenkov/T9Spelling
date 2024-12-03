// <copyright file="Program.cs" company="ASR">
// Copyright © 2024 ASR
// </copyright>

using T9SpellingApp.Transformers.File;

using T9SpellingApp.Transformers.String;

/// <summary>
/// Main application class.
/// </summary>
internal class Program
{
    private static readonly string AppDescription = "This console application copies string lines from source text file to another new with each string transformation.";

    private static void Main(string[] args)
    {
        string srcFilePath = string.Empty;
        string targetFilePath = string.Empty;
        bool bPathExists = false;

        // enter params
        if (args.Length == 0)
        {
            Console.WriteLine(AppDescription);
            Console.Write("Please, enter source text file full path: ");
            while (string.IsNullOrEmpty(srcFilePath) && !bPathExists)
            {
                srcFilePath = Console.ReadLine() ?? string.Empty;
                bPathExists = File.Exists(srcFilePath);
                if (!bPathExists)
                {
                    Console.Write("Wrong path or file doesn't exist. Please, enter source text file full path: ");
                    srcFilePath = string.Empty;
                }
            }

            Console.Write("Please, enter target text file full path: ");
            while (string.IsNullOrEmpty(targetFilePath))
            {
                targetFilePath = Console.ReadLine() ?? string.Empty;

                // checking dest folder
                if (!Directory.Exists(targetFilePath?.Substring(0, targetFilePath.LastIndexOf("\\"))))
                {
                    Console.Write("Wrong path. Please, enter target text file full path: ");
                    targetFilePath = string.Empty;
                }
            }
        } // or get ones
        else if (args.Length == 2)
        {
            srcFilePath = args[0] ?? string.Empty;
            targetFilePath = args[1] ?? string.Empty;
        }
        else
        {
            Console.WriteLine(AppDescription);
            Console.WriteLine("Usage: t9SpellingApp.exe sourceFilePath targetFilePath");
            Console.WriteLine(@"Example: t9SpellingApp.exe c:\Temp\sourceText.txt c:\Temp\targetText.txt");
            return;
        }

        // do transform
        if (!string.IsNullOrEmpty(srcFilePath) && !string.IsNullOrEmpty(targetFilePath))
        {
            try
            {
                new TextFileContentTransformer(new StringToNumKeyboardTransformer())
                    .Transform(srcFilePath, targetFilePath);
                Console.WriteLine("Done!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error has occured during processing. Error: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("Wrong parameters!");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}