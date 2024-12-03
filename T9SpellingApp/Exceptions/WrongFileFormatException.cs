// <copyright file="WrongFileFormatException.cs" company="ASR">
// Copyright © 2024 ASR
// </copyright>

namespace T9SpellingApp.Exceptions;

/// <summary>
/// Wrong file format exception class.
/// </summary>
public class WrongFileFormatException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WrongFileFormatException"/> class.
    /// </summary>
    public WrongFileFormatException()
    {
    }

    /// <<summary>
    /// Initializes a new instance of the <see cref="WrongFileFormatException"/> class.
    /// </summary>
    /// <param name="message">Message of exception.</param>
    public WrongFileFormatException(string message)
        : base(message)
    {
    }
}