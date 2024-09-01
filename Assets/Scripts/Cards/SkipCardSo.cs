using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card SO/Skip Card SO")]
    public class SkipCardSo: CardSo
    {
        private void OnValidate()
        {
            // Set the values directly in the script
            cardName = CardName.Skip;
            cardType = CardType.Action;
        }

        protected override void PlayCard()
        {
            base.PlayCard();
        }
    }
}
