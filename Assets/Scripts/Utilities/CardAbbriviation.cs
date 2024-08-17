using System;
using System.Collections.Generic;

public static class CardAbbriviation
{
    private static readonly Dictionary<CardTheme, string> ThemeAbbreviations = new()
    {
        { CardTheme.Original, "ORG"}
        // Add other themes here as needed
    };

    private static readonly Dictionary<CardName, string> NameAbbreviations = new()
    {
        { CardName.Attack, "ATK"},
        { CardName.Defuse, "DEF"},
        { CardName.ExplodingPaws, "EXP"},
        { CardName.Favor, "FVR"},
        { CardName.Nope, "NOP"},
        { CardName.SeeTheFuture, "STF"},
        { CardName.Shuffle, "SFL"},
        { CardName.Skip, "SKP"},
        // Add other card names here as needed
    };

    public static string GetCardThemeAbbreviations(CardTheme cardTheme)
    {
        // Check if the custom abbreviation is available
        if (ThemeAbbreviations.ContainsKey(cardTheme))
            return ThemeAbbreviations[cardTheme];
        else // fallback to generating abbreviation
            return GetAbbreviation(cardTheme.ToString());
    }

    public static string GetCardNameAbbreviations(CardName cardName)
    {
        // Check if the custom abbreviation is available
        if (NameAbbreviations.ContainsKey(cardName))
            return NameAbbreviations[cardName];
        else // fallback to generating abbreviation
            return GetAbbreviation(cardName.ToString());
    }

    private static string GetAbbreviation(string fullString, int abvSize = 3)
    {
        return fullString[..Math.Min(abvSize, fullString.Length)].ToUpper();
    }
}
