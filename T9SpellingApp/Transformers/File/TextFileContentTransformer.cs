// <copyright file="TextFileContentTransformer.cs" company="ASR">
// Copyright © 2024 ASR
// </copyright>

namespace T9SpellingApp.Transformers.File;

using T9SpellingApp.Exceptions;
using T9SpellingApp.Interfaces;
using T9SpellingApp.Extensions;
using System.Text;

/// <summary>
/// Transforms string lines from source text file to target one.
/// </summary>
/// <param name="stringTransformer">Transformer object for file string lines.</param>
/// <param name="numberOfCases">Max number of cases to transform number.</param>
public class TextFileContentTransformer(IStringTransformer stringTransformer, int numberOfCases = 100)
{
    private readonly string stringTemplate = "Case #{0}: {1}";

    /// <summary>
    /// Gets maximal number of cases value.
    /// </summary>
    public int NumberOfCases { get; } = numberOfCases;

    /// <summary>
    /// Gets value of transformer object for string.
    /// </summary>
    public IStringTransformer StringTransformer { get; } = stringTransformer;

    /// <summary>
    /// Reads string lines from source file and copies into target one with litteral transformation.
    /// </summary>
    /// <param name="srcFileFullPath">Full path to source text file.</param>
    /// <param name="targetFilePath">Full path to target text file.</param>
    /// <exception cref="WrongFileFormatException">Occured if file is empty or has unexpected format.</exception>
    public void Transform(string srcFileFullPath, string targetFilePath)
    {
        var transformedLines = new StringBuilder();

        var srcFileLines = System.IO.File.ReadLines(srcFileFullPath);
        {
            // checking if file is empty
            if (!srcFileLines.Any())
            {
                throw new WrongFileFormatException("File is empty!");
            }
            else
            {
                var linesCounter = srcFileLines.First();

                // checking file content format
                if (!linesCounter!.IsNumeric(out int numStr))
                {
                    throw new WrongFileFormatException("First line doesn't have valid format!");
                }
                else if (numStr > this.NumberOfCases)
                {
                    throw new WrongFileFormatException("Number of cases is greater than available!");
                }
                else if (numStr > srcFileLines.Count() - 1)
                {
                    throw new WrongFileFormatException("Number of cases is greater than string lines!");
                }
                else
                {
                    // do transformation
                    var counter = 1;
                    foreach (var line in srcFileLines.Skip(1))
                    {
                        transformedLines.AppendLine(string.Format(this.stringTemplate, counter++, this.StringTransformer.Transform(line)));
                    }
                }

                System.IO.File.WriteAllText(targetFilePath, transformedLines.ToString());
            }
        }
    }
}
