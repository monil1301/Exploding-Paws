using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card SO/Favor Card SO")]
    public class FavorCardSo: CardSo
    {
        private void OnValidate()
        {
            // Set the values directly in the script
            cardName = CardName.Favor;
            cardType = CardType.Action;
        }

        protected override void PlayCard()
        {
            base.PlayCard();
        }
    }
}
