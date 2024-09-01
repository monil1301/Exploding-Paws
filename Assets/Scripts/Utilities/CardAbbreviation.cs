using System;
using System.Collections.Generic;

namespace Utilities
{
    public static class CardAbbreviation
    {
        private static readonly Dictionary<CardTheme, string> ThemeAbbreviations = new()
        {
            { CardTheme.Original, "ORG" }
            // Add other themes here as needed
        };

        private static readonly Dictionary<CardName, string> NameAbbreviations = new()
        {
            { CardName.Attack, "ATK" },
            { CardName.Defuse, "DEF" },
            { CardName.ExplodingPaws, "EXP" },
            { CardName.Favor, "FVR" },
            { CardName.Nope, "NOP" },
            { CardName.SeeTheFuture, "STF" },
            { CardName.Shuffle, "SFL" },
            { CardName.Skip, "SKP" },
            // Add other card names here as needed
        };

        public static string GetCardThemeAbbreviations(CardTheme cardTheme)
        {
            // Check if the custom abbreviation is available
            return ThemeAbbreviations.TryGetValue(cardTheme, out var themeAbbreviation)
                ? themeAbbreviation
                : GetAbbreviation(cardTheme.ToString()); // fallback to generating abbreviation
        }

        public static string GetCardNameAbbreviations(CardName cardName)
        {
            // Check if the custom abbreviation is available
            return NameAbbreviations.TryGetValue(cardName, out var nameAbbreviation)
                ? nameAbbreviation
                : GetAbbreviation(cardName.ToString()); // fallback to generating abbreviation
        }

        private static string GetAbbreviation(string fullString, int abvSize = 3)
        {
            return fullString[..Math.Min(abvSize, fullString.Length)].ToUpper();
        }
    }
}