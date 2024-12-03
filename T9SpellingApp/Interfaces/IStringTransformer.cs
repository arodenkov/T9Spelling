// <copyright file="IStringTransformer.cs" company="ASR">
// Copyright © 2024 ASR
// </copyright>

namespace T9SpellingApp.Interfaces;

/// <summary>
/// 
/// </summary>
internal interface IStringTransformer
{
    /// <summary>
    /// Transform string to symbol codes string.
    /// </summary>
    /// <param name="s">String to transform.</param>
    /// <returns>Transformed string.</returns>
    public string Transform(string s);

    /// <summary>
    /// Transform letter to symbol codes string.
    /// </summary>
    /// <param name="ch">Letter symbol to transform.</param>
    /// <returns>Transformed string.</returns>
    public string Transform(char ch);
}
