﻿// <copyright file="StringToNumKeyboardTransformer.cs" company="ASR">
// Copyright © 2024 ASR
// </copyright>

namespace T9SpellingApp.Transformers;

using System.Linq;
using System.Text.RegularExpressions;
using System.Transactions;
using T9SpellingApp.Exceptions;
using T9SpellingApp.Interfaces;

/// <summary>
/// Transforms string to numbered keyboard symbol codes output string.
/// </summary>
/// <param name="checkConditions">Parameter to set input string conditions checking before any transformation.</param>
/// <param name="stringMaxLength">Parameter to set input string length.</param>
public class StringToNumKeyboardTransformer(bool checkConditions = true, int stringMaxLength = 1000) : IStringTransformer
{
    private static readonly Dictionary<char, string> TransformationRules = new Dictionary<char, string>()
    {
        { 'a', "2" },
        { 'b', "22" },
        { 'c', "222" },
        { 'd', "3" },
        { 'e', "33" },
        { 'f', "333" },
        { 'g', "4" },
        { 'h', "44" },
        { 'i', "444" },
        { 'j', "5" },
        { 'k', "55" },
        { 'l', "555" },
        { 'm', "6" },
        { 'n', "66" },
        { 'o', "666" },
        { 'p', "7" },
        { 'q', "77" },
        { 'r', "777" },
        { 's', "7777" },
        { 't', "8" },
        { 'u', "88" },
        { 'v', "888" },
        { 'w', "9" },
        { 'x', "99" },
        { 'y', "999" },
        { 'z', "9999" },
        { ' ', "0" },
    };

    private Regex latinStringRegEx = new Regex("^[a-z]*$");

    private string prevLetter = string.Empty;

    /// <summary>
    /// Gets a value indicating whether needs to check input string conditions before any transformation.
    /// </summary>
    public bool CheckConditions { get; private set; } = checkConditions;

    /// <summary>
    /// Gets or sets value of maximal allowed input string length.
    /// </summary>
    public int StringMaxLength { get; set; } = stringMaxLength;

    /// <inheritdoc/>
    public string Transform(string s)
    {
        if (this.IsValid(s))
        {
            return string.Join(string.Empty, s.Select(this.Transform));
        }

        throw new InvalidDataException("String is not valid!");
    }

    /// <inheritdoc/>
    public string Transform(char ch)
    {
        string result;
        if (TransformationRules.TryGetValue(ch, out result!))
        {
            if (this.prevLetter != result)
            {
                this.prevLetter = result;
            }
            else
            {
                result = string.Empty + result;
            }

            return result;
        }
        else
        {
            throw new WrongLetterException($"Letter '{ch}' was not found in transformation rules!");
        }
    }

    private bool IsValid(string s)
    {
        if (this.CheckConditions)
        {
            if (s is null)
            {
                throw new ArgumentNullException("Input string is null!");
            }

            if (s == string.Empty)
            {
                throw new ArgumentException("Input string is empty!");
            }

            if (s.Length > this.StringMaxLength)
            {
                throw new ArgumentException($"Input string length is out of limit of {this.StringMaxLength}!");
            }

            if (!this.latinStringRegEx.IsMatch(s))
            {
                throw new ArgumentException("Input string has one or more non latin letters or some letters in upper case!");
            }
        }

        return true;
    }
}