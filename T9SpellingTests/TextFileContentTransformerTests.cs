// <copyright file="TextFileContentTransformerTests.cs" company="ASR">
// Copyright © 2024 ASR
// </copyright>

namespace T9SpellingTests;

using T9SpellingApp.Exceptions;
using T9SpellingApp.Transformers.File;
using T9SpellingApp.Transformers.String;

/// <summary>
/// Text file content transformation nunit test class.
/// </summary>
public class TextFileContentTransformerTests
{
    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// Not exists source file transformation test.
    /// </summary>
    [Test]
    public void NotExistsSourceFileTransformationWithExceptionAsResultTest()
    {
        try
        {
            new TextFileContentTransformer(new StringToNumKeyboardTransformer())
                .Transform(
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Source", "srcnotexists.txt"),
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Target", "trg.txt"));
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }

        Assert.Fail("Test passed unsuccessfully! Exception is expected!");
    }

    /// <summary>
    /// Exists target file transformation test.
    /// </summary>
    [Test]
    public void ExistsTargetFileTransformationTest()
    {
        try
        {
            new TextFileContentTransformer(new StringToNumKeyboardTransformer())
                .Transform(
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Source", "src01.txt"),
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Target", "trg01.txt"));
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }

        Assert.Pass("Test passed successfully!");
    }

    /// <summary>
    /// Source file to target transformation test.
    /// </summary>
    [Test]
    public void SourceToTargetFileTransformationTest()
    {
        try
        {
            new TextFileContentTransformer(new StringToNumKeyboardTransformer())
                .Transform(
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Source", "src02.txt"),
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Target", "trg02.txt"));
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }

        Assert.Pass("Test passed successfully!");
    }

    /// <summary>
    /// Large source file to target transformation test.
    /// </summary>
    [Test]
    public void LargeSourceToTargetFileTransformationTest()
    {
        try
        {
            new TextFileContentTransformer(new StringToNumKeyboardTransformer())
                .Transform(
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Source", "srcLarge.txt"),
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Target", "trgLarge.txt"));
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }

        Assert.Pass("Test passed successfully!");
    }

    /// <summary>
    /// Source file with wrong number of cases to target transformation test.
    /// </summary>
    [Test]
    public void WrongNumberOfCasesSourceToTargetFileTransformationWithExceptionAsResultTest()
    {
        try
        {
            new TextFileContentTransformer(new StringToNumKeyboardTransformer())
                .Transform(
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Source", "srcWithWrongNumberOfCases.txt"),
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Target", "trgWithWrongNumberOfCases.txt"));
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }

        Assert.Fail("Test passed unsuccessfully! Exception is expected!");
    }

    /// <summary>
    /// Source file with wrong number of cases to target transformation test.
    /// </summary>
    [Test]
    public void WrongNumberOfCasesSourceToTargetFileTransformationWithExceptionAsResultTest02()
    {
        try
        {
            new TextFileContentTransformer(new StringToNumKeyboardTransformer(), 2)
                .Transform(
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Source", "srcWithWrongNumberOfCases02.txt"),
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Target", "trgWithWrongNumberOfCases02.txt"));
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }

        Assert.Fail("Test passed unsuccessfully! Exception is expected!");
    }

    /// <summary>
    /// Source file to target with wrong number of cases format transformation test.
    /// </summary>
    [Test]
    public void WrongNumberOfCasesFormatSourceToTargetFileTransformationWithExceptionAsResultTest()
    {
        try
        {
            new TextFileContentTransformer(new StringToNumKeyboardTransformer())
                .Transform(
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Source", "srcWrongFormat.txt"),
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Target", "trgWrongFormat.txt"));
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }

        Assert.Fail("Test passed unsuccessfully! Exception is expected!");
    }

    /// <summary>
    /// Source file to target with wrong number of cases format transformation test.
    /// </summary>
    [Test]
    public void WrongLinesFormatSourceToTargetFileTransformationWithExceptionAsResultTest()
    {
        try
        {
            new TextFileContentTransformer(new StringToNumKeyboardTransformer())
                .Transform(
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Source", "srcWrongLinesFormat.txt"),
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Target", "trgWrongLinesFormat.txt"));
        }
        catch (ArgumentException ex)
        {
            Assert.Pass($"Test passed successfully! Expected exception: {ex.ToString()}");
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }

        Assert.Fail("Test passed unsuccessfully! Exception is expected!");
    }

    /// <summary>
    /// Source empty file to target transformation test.
    /// </summary>
    [Test]
    public void EmptySourceToTargetFileTransformationWithExceptionAsResultTest()
    {
        try
        {
            new TextFileContentTransformer(new StringToNumKeyboardTransformer())
                .Transform(
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Source", "srcEmpty.txt"),
                    Path.Combine(TestContext.CurrentContext.TestDirectory, "Files", "Target", "trgEmpty.txt"));
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }

        Assert.Fail("Test passed unsuccessfully! Exception is expected!");
    }

    private void ProcessException(Exception ex)
    {
        if (ex is WrongFileFormatException || ex is FileNotFoundException || ex is DirectoryNotFoundException || ex is IOException)
        {
            Assert.Pass($"Test passed successfully! Expected exception: {ex.ToString()}");
        }
        else
        {
            Assert.Fail($"Test passed unsuccessfully! Unexpected exception: {ex.ToString()}");
        }
    }
}