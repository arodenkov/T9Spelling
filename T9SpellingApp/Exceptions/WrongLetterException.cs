// <copyright file="WrongLetterException.cs" company="ASR">
// Copyright © 2024 ASR
// </copyright>

namespace T9SpellingApp.Exceptions;

/// <summary>
/// Wrong letter exception class.
/// </summary>
public class WrongLetterException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WrongLetterException"/> class.
    /// </summary>
    public WrongLetterException()
    {
    }

    /// <<summary>
    /// Initializes a new instance of the <see cref="WrongLetterException"/> class.
    /// </summary>
    /// <param name="message">Message of exception.</param>
    public WrongLetterException(string message)
        : base(message)
    {
    }
}