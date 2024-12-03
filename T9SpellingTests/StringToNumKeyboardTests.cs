// <copyright file="StringToNumKeyboardTests.cs" company="ASR">
// Copyright © 2024 ASR
// </copyright>

namespace T9SpellingTests;

using NUnit.Framework.Internal;
using T9SpellingApp.Exceptions;
using T9SpellingApp.Transformers.String;

/// <summary>
/// String to numeric keyboard transformation nunit test class.
/// </summary>
public class StringToNumKeyboardTests
{
    private StringToNumKeyboardTransformer str2numTransformer = new ();

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    [SetUp]
    public void Setup()
    {
    }

    /// <summary>
    /// String transformation with null value string test.
    /// </summary>
    [Test]
    public void NullStringWithExceptionAsResultTest()
    {
        try
        {
            Assert.Fail(this.str2numTransformer.Transform(s: null!));
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }
    }

    /// <summary>
    /// Empty value string transformation test.
    /// </summary>
    [Test]
    public void EmptyStringWithExceptionAsResultTest()
    {
        try
        {
            Assert.Fail(this.str2numTransformer.Transform(string.Empty));
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }
    }

    /// <summary>
    /// Cyrillic letters string transformation test.
    /// </summary>
    [Test]
    public void NonLatinLettersWithExceptionAsResultTest01()
    {
        try
        {
            Assert.Fail(this.str2numTransformer.Transform("ûâàûõçæ"));
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }
    }

    /// <summary>
    /// String with numbers and cyrillic letters transformation test.
    /// </summary>
    [Test]
    public void NonLatinLettersWithExceptionAsResultTest02()
    {
        try
        {
            Assert.Fail(this.str2numTransformer.Transform("123141âûÀÛûâÿ÷"));
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }
    }

    /// <summary>
    /// String transformation test with latin and a few upper case letters.
    /// </summary>
    [Test]
    public void CapitalCaseWithExceptionAsResultTest()
    {
        try
        {
            Assert.Fail(this.str2numTransformer.Transform("aBcDe"));
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }
    }

    /// <summary>
    /// Excessive length string transformation test.
    /// </summary>
    [Test]
    public void OverLongStringWithExceptionAsResultTest()
    {
        try
        {
            this.str2numTransformer.Transform(new string('q', 1001));
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }

        Assert.Fail("Test passed unsuccessfully! Exception is expected!");
    }

    /// <summary>
    /// Long string transformation test.
    /// </summary>
    [Test]
    public void LongStringTest()
    {
        try
        {
            var res = this.str2numTransformer.Transform(new string('q', 1000));
            Assert.That(res.Length > 0, "Test passed unsuccessfully!");
        }
        catch (Exception ex)
        {
            this.ProcessException(ex);
        }

        Assert.Pass("Test passed successfully!");
    }

    /// <summary>
    /// String with double letters transformation test.
    /// </summary>
    [Test]
    public void StringWithDoublesTest()
    {
        var res = this.str2numTransformer.Transform("abbcdddee");
        Assert.That(res == "2 22 22 2223 3 3 33 33", $"Test passed unsuccessfully! Result string: \"{res}\"");
        Assert.Pass($"Test passed successfully! Result string: \"{res}\"");
    }

    /// <summary>
    /// String with double letters and spaces transformation test.
    /// </summary>
    [Test]
    public void StringWithDoublesAndSpacesTest()
    {
        var res = this.str2numTransformer.Transform("abb cddd ee");
        Assert.That(res == "2 22 2202223 3 3033 33", $"Test passed unsuccessfully! Result string: \"{res}\"");
        Assert.Pass($"Test passed successfully! Result string: \"{res}\"");
    }

    /// <summary>
    /// String with valid letters test.
    /// </summary>
    [Test]
    public void StringTest01()
    {
        var res = this.str2numTransformer.Transform("hi");
        Assert.That(res == "44 444", $"Test passed unsuccessfully! Result string: \"{res}\"");
        Assert.Pass($"Test passed successfully! Result string: \"{res}\"");
    }

    /// <summary>
    /// String with valid letters test.
    /// </summary>
    [Test]
    public void StringTest02()
    {
        var res = this.str2numTransformer.Transform("yes");
        Assert.That(res == "999337777", $"Test passed unsuccessfully! Result string: \"{res}\"");
        Assert.Pass($"Test passed successfully! Result string: \"{res}\"");
    }

    /// <summary>
    /// String with valid letters test.
    /// </summary>
    [Test]
    public void StringTest03()
    {
        var res = this.str2numTransformer.Transform("foo  bar");
        Assert.That(res == "333666 6660 022 2777", $"Test passed unsuccessfully! Result string: \"{res}\"");
        Assert.Pass($"Test passed successfully! Result string: \"{res}\"");
    }

    /// <summary>
    /// String with valid letters test.
    /// </summary>
    [Test]
    public void StringTest04()
    {
        var res = this.str2numTransformer.Transform("hello world");
        Assert.That(res == "4433555 555666096667775553", $"Test passed unsuccessfully! Result string: \"{res}\"");
        Assert.Pass($"Test passed successfully! Result string: \"{res}\"");
    }

    private void ProcessException(Exception ex)
    {
        if (ex is WrongLetterException || ex is ArgumentException)
        {
            Assert.Pass($"Test passed successfully! Expected exception: {ex.ToString()}");
        }
        else
        {
            Assert.Fail($"Test passed unsuccessfully! Unexpected exception: {ex.ToString()}");
        }
    }
}