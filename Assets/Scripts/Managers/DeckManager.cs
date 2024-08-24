using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;
using Logger = Utilities.Logger;

namespace Managers
{
    public class DeckManager : MonoBehaviour
    {
        public List<CardSO> deck = new();
        [SerializeField] private List<CardSO> cardSOs;

        private void CreateDeck(CardTheme cardTheme)
        {
            switch (cardTheme)
            {
                case CardTheme.Original:
                    CreateOriginalPack();
                    break;
                default:
                    Logger.LogError("Theme not found for creating deck", ("theme", cardTheme));
                    break;
            }
        }

        private void CreateOriginalPack()
        {
            cardSOs.ForEach(cardSo =>
            {
                // Try to get the count of a type of card if it exists in the pack
                CardPackInventory.OriginalCardPack.CardsInPack.TryGetValue(cardSo.cardName, out int count);

                // Adds a type of card for <count> times in the deck 
                deck.AddRange(Enumerable.Repeat(cardSo, count));
            });
        }
    }
}
