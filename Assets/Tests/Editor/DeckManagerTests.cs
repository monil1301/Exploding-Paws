using System.Collections.Generic;
using Cards;
using Managers;
using NUnit.Framework;
using UnityEngine;

namespace Tests.Editor
{
    public class DeckManagerTests
    {
        private DeckManager deckManager;

        [SetUp]
        public void Setup()
        {
            var gameObject = new GameObject();
            deckManager = gameObject.AddComponent<DeckManager>();

            gameObject.SetActive(true);

            // Mock the cardSOs list with some data
            deckManager.GetType()
                .GetField("deck", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(deckManager, MockCardSOs());
        }
        
        private static List<CardSo> MockCardSOs()
        {
            var card1 = ScriptableObject.CreateInstance<CardSo>();
            card1.cardName = CardName.Attack;

            var card2 = ScriptableObject.CreateInstance<CardSo>();
            card2.cardName = CardName.Defuse;

            var card3 = ScriptableObject.CreateInstance<CardSo>();
            card3.cardName = CardName.Shuffle;

            // Mock some cards
            return new List<CardSo>
            {
                card1, card2, card3
            };
        }

        #region Draw Tests

        [Test]
        public void Draw_ReturnsTopCard_WhenDeckIsNotEmpty()
        {
            // Arrange
            var originalList = new List<CardSo>(deckManager.Deck);

            // Act
            var result = deckManager.Draw();

            // Assert
            Assert.AreEqual(originalList[^1].cardName, result.cardName);
        }

        [Test]
        public void Draw_ReturnsNull_WhenDeckIsEmpty()
        {
            // Arrange
            // Mock the cardSOs list with empty list
            deckManager.GetType()
                .GetField("deck", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(deckManager, new List<CardSo>());

            // Act
            var result = deckManager.Draw();

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Draw_SizeReduction_WhenDrawnFromDeck()
        {
            // Arrange
            var originalDeck = new List<CardSo>(deckManager.Deck);

            // Act
            deckManager.Draw();

            // Assert
            Assert.AreEqual(deckManager.Deck.Count, originalDeck.Count - 1);
        }

        #endregion

        #region Shuffle Tests
        
        [Test]
        public void Shuffle_DeckOrderChanges()
        {
            // Arrange
            var originalOrder = new List<CardSo>(deckManager.Deck);
        
            // Act
            deckManager.Shuffle();
        
            // Assert
            CollectionAssert.AreEquivalent(originalOrder, deckManager.Deck, "Shuffled deck should contain the same elements.");
            CollectionAssert.AreNotEqual(originalOrder, deckManager.Deck, "Shuffled deck order should be different.");
        }
        
        [Test]
        public void Shuffle_DoesNotChangeDeckSize()
        {
            // Arrange
            var originalSize = deckManager.Deck.Count;
        
            // Act
            deckManager.Shuffle();
        
            // Assert
            Assert.AreEqual(originalSize, deckManager.Deck.Count, "Deck size should remain the same after shuffling.");
        }
        
        #endregion
        
        #region Peek Top Cards Test
        
        [Test]
        public void PeekTopCards_ReturnsTopNCard_WhenDeckIsNotEmpty()
        {
            // Arrange
            var originalList = deckManager.Deck;
        
            // Act
            var result = deckManager.PeekTopNCards(2);
        
            // Assert
            Assert.AreEqual(result[0].cardName, originalList[^1].cardName);
            Assert.AreEqual(result[1].cardName, originalList[^2].cardName);
        }
        
        [Test]
        public void PeekTopCards_DoesNotChangeDeckSize()
        {
            // Arrange
            var originalDeck = new List<CardSo> (deckManager.Deck);
        
            // Act
            deckManager.PeekTopNCards(2);
        
            // Assert
            Assert.AreEqual(originalDeck.Count, deckManager.Deck.Count);
        }
        
        [Test]
        public void PeekTopCards_ReturnsNull_WhenDeckIsEmpty()
        {
            // Arrange
            // Mock the cardSOs list with empty list
            deckManager.GetType()
                .GetField("deck", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.SetValue(deckManager, new List<CardSo>());
        
            // Act
            var result = deckManager.PeekTopNCards(2);
        
            // Assert
            Assert.IsNull(result);
        }
        #endregion
    }
}
