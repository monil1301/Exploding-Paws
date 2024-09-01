using UnityEngine;
using Utilities;

namespace Cards
{
   [CreateAssetMenu(menuName = "Card SO")]
   public class CardSo : ScriptableObject
   {
      public int cardNumber;
      public CardName cardName;
      public string cardActionDescription;
      public Sprite cardIcon;
      public CardTheme cardTheme;
      public CardType cardType;
      public CardRarity cardRarity;
      public Sprite cardFrame;

      [HideInInspector]
      public string cardID; // Hidden in inspector to avoid accidentally updating it

      private void GenerateCardID()
      {
         var themeAbbreviation = CardAbbreviation.GetCardThemeAbbreviations(cardTheme);
         var nameAbbreviation = CardAbbreviation.GetCardNameAbbreviations(cardName);

         cardID = $"{themeAbbreviation}_{nameAbbreviation}_{cardNumber:D3}";
      }

      // Automatically generate the card ID when the ScriptableObject is modified
      private void OnValidate()
      {
         GenerateCardID();
      }

      protected virtual void PlayCard()
      {
         
      }
   }
}
