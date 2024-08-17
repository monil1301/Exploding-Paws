using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    // Lists to get references from unity
    [SerializeField] private List<CardThemeData> cardBackThemes = new();
    [SerializeField] private List<CardThemeData> cardFaceThemes = new();

    // Class for binding theme and sprites
    [System.Serializable]
    public class CardThemeData
    {
        public CardTheme cardTheme;
        public Sprite cardImage;
    }

    private void Start()
    {
        Dictionary<CardTheme, Sprite> cardBackThemeDictionary = new();
        Dictionary<CardTheme, Sprite> cardFaceThemeDictionary = new();

        // Check for card back themes and make a dictionary
        if (cardBackThemes.IsNullOrEmpty() == false)
        {
            cardBackThemes.ForEach(theme =>
            {
                cardBackThemeDictionary.Add(theme.cardTheme, theme.cardImage);
            });
        }

        // Check for card face themes and make a dictionary
        if (cardFaceThemes.IsNullOrEmpty() == false)
        {
            cardFaceThemes.ForEach(theme =>
            {
                cardFaceThemeDictionary.Add(theme.cardTheme, theme.cardImage);
            });
        }

        // Initialise the theme dictionary with above prepared dictioaries
        ThemeDictionary.Initialize(cardBackThemeDictionary, cardFaceThemeDictionary);

        // Destroy this gameobject to free memory as we have the themes set up
        Destroy(gameObject);
    }
}
