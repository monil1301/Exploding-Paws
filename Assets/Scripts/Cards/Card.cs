using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cards
{
    public class Card : MonoBehaviour
    {
        #region Referenced elements
        [SerializeField] private Image frame;

        [Header("Card BG")]
        [SerializeField] private Image bg;

        [Header("Top")]
        [SerializeField] private Image topIcon;
        [SerializeField] private TMP_Text topTitle, funText;

        [Header("Center")]
        [SerializeField] private Image centerImage;
        [SerializeField] private TMP_Text description;

        [Header("Bottom")]
        [SerializeField] private Image bottomIcon;
        [SerializeField] private TMP_Text bottomTitle;
        #endregion

        #region Private properties
        private CardSo cardData;
        #endregion

        #region Public properties
        // Indicates whether the card is facing up (true) or down (false)
        public bool IsFacingUp { get; private set; }
        #endregion

        #region Public methods
        // Initialize the card with data
        public void Initialize(CardSo cardSo)
        {
            // Return if the cardSO is null
            if (cardSo == null)
                return;

            // Assign cardSO to variable that can be accessed from all the methods in the file
            cardData = cardSo;

            // Assign border of the card
            if (cardData.cardFrame != null)
                frame.sprite = cardData.cardFrame;

            // Assign the icon of the card (both top left and bottom right)
            if (cardData.cardIcon != null)
            {
                topIcon.sprite = cardData.cardIcon;
                bottomIcon.sprite = cardData.cardIcon;
            }

            // Assign name of the card (both top and bottom)
            topTitle.text = cardData.cardName.ToString();
            bottomTitle.text = cardData.cardName.ToString();

            // Assign the description of the card
            description.text = cardData.cardActionDescription;
        }

        // Flip the card (Face Up to Face Down and vice versa)
        public void FlipCard()
        {
            IsFacingUp = !IsFacingUp; // Toggle the facing state
            UpdateCardVisual();
        }
        #endregion

        // Update the card's visual based on its facing state
        private void UpdateCardVisual()
        {
            frame.gameObject.SetActive(IsFacingUp); // Frame is only for facing up card 

            // Get theme based face or back sprite based on the facing value
            bg.sprite = IsFacingUp ? ThemeDictionary.GetCardFaceSprite(cardData.cardTheme) : ThemeDictionary.GetCardBackSprite(cardData.cardTheme);
        }
    }
}
