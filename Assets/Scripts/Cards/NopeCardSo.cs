using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card SO/Nope Card SO")]
    public class NopeCardSo: CardSo
    {
        private void OnValidate()
        {
            // Set the values directly in the script
            cardName = CardName.Nope;
            cardType = CardType.Defensive;
        }

        protected override void PlayCard()
        {
            base.PlayCard();
        }
    }
}
