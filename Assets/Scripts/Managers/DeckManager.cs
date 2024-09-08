using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Cards;
using Extensions;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using Logger = Utilities.Logger;
using Random = System.Random;

namespace Managers
{
    public class DeckManager : MonoBehaviour
    {
        #region Serialized fields
        
        [SerializeField] private List<CardSo> cardSOs;
        [SerializeField] private Button drawButton;

        #endregion
        
        #region Private fields
        
        private readonly List<CardSo> deck = new();
        private readonly List<CardSo> discardPile = new();
        
        #endregion
        
        #region Public fields
        
        public ReadOnlyCollection<CardSo> Deck => deck.AsReadOnly();

        #endregion
        
        #region Unity lifecycle
        
        private void Start()
        {
            CreateDeck(CardTheme.Original);
            AddClickListeners();
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

            Debug.Log($"Deck created successfully with {deck.Count} cards");
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

        /**
         * Add the card back to the deck
         * <param name="cardSo">Card that needs to be put back in the deck</param>
         * <param name="index">Index at which the card needs to be inserted</param>
         * <returns>A boolean if the card was successfully put back in the deck or not</returns>
         */
        public bool PutBack(CardSo cardSo, int index = -1)
        {
            // Return false if the card is null OR index is more than the deck cards count
            if (cardSo == null || index >= deck.Count) return false;

            // If the index is default (-1) than make index as a random value between 0 and deck cards count
            if (index == -1)
            {
                Random random = new();
                index = random.Next(deck.Count);
            }
            
            // put the card at index in the deck
            deck.Insert(index, cardSo);
            return true;
        }
        
        /**
         * Adds the card to the discarded pile
         * <param name="cardSo">Card to be discarded</param>
         */
        public void Discard(CardSo cardSo)
        {
            discardPile.Add(cardSo);
        }

        /**
         * Gives the top card of the discarded pile
         * <returns>Null if the list is empty; else the last card of the list</returns>
         */
        public CardSo LastDiscardedCard()
        {
            return discardPile.IsNullOrEmpty() ? null : discardPile[^1];
        }
        #endregion

        #region Button Clicks

        private void AddClickListeners()
        {
            drawButton.onClick.AddListener(OnDrawButtonClicked);
        }

        private void OnDrawButtonClicked()
        {
            Debug.Log("Deck Button Clicked");
        }

        #endregion
    }
}
