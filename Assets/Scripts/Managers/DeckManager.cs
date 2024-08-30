using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cards;
using Extensions;
using UnityEngine;
using Utilities;
using Logger = Utilities.Logger;
using Random = System.Random;

namespace Managers
{
    public class DeckManager : MonoBehaviour
    {
        #region Serialized fields
        
        [SerializeField] private List<CardSo> cardSOs;

        #endregion
        
        #region Private fields
        
        private readonly List<CardSo> deck = new();
        
        #endregion
        
        #region Public fields
        
        public ReadOnlyCollection<CardSo> Deck => deck.AsReadOnly();

        #endregion
        
        #region Unity lifecycle
        
        private void Start()
        {
            CreateDeck(CardTheme.Original);
        }
        
        #endregion

        #region Deck creation
        
        // Creates the deck for the gameplay based on the theme
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

        #endregion
        
        #region Deck operations
        
        /**
         * Shuffles the deck (list of CardSo)
         */
        public void Shuffle()
        {
            Random random = new();
            var remainingCardsToShuffle = deck.Count;

            // Loop till the last card in the deck
            while (remainingCardsToShuffle > 1)
            {
                remainingCardsToShuffle--;
                var randomIndex =
                    random.Next(remainingCardsToShuffle + 1); // Get random index from the remaining deck cards
            
                // Swap card at random index with card at top of remaining cards to shuffle
                (deck[randomIndex], deck[remainingCardsToShuffle]) = (deck[remainingCardsToShuffle], deck[randomIndex]);
            }
        }

        /**
         * Gives a card from the top of the deck i.e. from end of the list
         * <returns>CardSo</returns>
         */
        public CardSo Draw()
        {
            // Check if the deck is empty or not
            if (deck.IsNullOrEmpty()) return null;
            
            // Return the top card and remove from the dec
            var top =  deck.Last();
            deck.Remove(top);
            return top;
        }

        /**
         * Returns the top N cards from the deck without modifying the deck
         *
         * <param name="n">Number of cards to peek</param>
         * <returns>List of CardSo of size N</returns>
         */
        public List<CardSo> PeekTopNCards(int n)
        {
            // Check if the deck is empty or not
            if (deck.IsNullOrEmpty()) return null;
            
            // Gives top N cards from the deck
            var topNCards = deck.GetRange(deck.Count - n, n);
            topNCards.Reverse();
            
            return topNCards;
        }
        
        #endregion
    }
}
