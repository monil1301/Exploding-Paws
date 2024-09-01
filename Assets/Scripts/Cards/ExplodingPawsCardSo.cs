using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card SO/Exploding Paws Card SO")]
    public class ExplodingPawsCardSo: CardSo
    {
        private void OnValidate()
        {
            // Set the values directly in the script
            cardName = CardName.ExplodingPaws;
            cardType = CardType.Explosive;
        }

        protected override void PlayCard()
        {
            base.PlayCard();
        }
    }
}
