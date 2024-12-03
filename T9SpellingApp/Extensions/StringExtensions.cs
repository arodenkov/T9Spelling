// <copyright file="StringExtensions.cs" company="ASR">
// Copyright © 2024 ASR
// </copyright>

namespace T9SpellingApp.Extensions;

/// <summary>
/// String estension class.
/// </summary>
internal static class StringExtensions
{
    /// <summary>
    /// Checking string is numeric.
    /// </summary>
    /// <param name="str">String to check.</param>
    /// <param name="num">String as a number.</param>
    /// <returns>True if string is numeric, otherwise false.</returns>
    public static bool IsNumeric(this string str, out int num)
    {
        return int.TryParse(str, out num);
    }
}
