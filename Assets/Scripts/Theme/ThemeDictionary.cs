using System.Collections.Generic;
using UnityEngine;

public static class ThemeDictionary
{
    // Dictionaries for storing sprites and theme relation
    private static Dictionary<CardTheme, Sprite> cardBackThemes = new();
    private static Dictionary<CardTheme, Sprite> cardFaceThemes = new();

    // Initialize the themes here
    public static void Initialize(
        Dictionary<CardTheme, Sprite> cardBackTheme,
        Dictionary<CardTheme, Sprite> cardFaceTheme
    )
    {
        cardBackThemes = cardBackTheme;
        cardFaceThemes = cardFaceTheme;
    }

    #region Getter methods
    // Gives sprite for the back of the card i.e. when the card is faced down
    public static Sprite GetCardBackSprite(CardTheme theme)
    {
        if (cardBackThemes.TryGetValue(theme, out Sprite sprite)) // try to get from the sprite from dictionary
        {
            return sprite;
        }
        Debug.LogWarning("Back theme not found: " + theme);
        return null;
    }

    // Gives sprite for the front bg of the card i.e. when the card is faced up
    public static Sprite GetCardFaceSprite(CardTheme theme)
    {
        if (cardFaceThemes.TryGetValue(theme, out Sprite sprite)) // try to get from the sprite from dictionary
        {
            return sprite;
        }
        Debug.LogWarning("Face theme not found: " + theme);
        return null;
    }
    #endregion
}
