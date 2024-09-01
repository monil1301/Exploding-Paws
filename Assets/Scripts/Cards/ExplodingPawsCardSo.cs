using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card SO/Exploding Paws Card SO")]
    public class ExplodingPawsCardSo: CardSo
    {
        protected override void OnValidate()
        {
            // Set the values directly in the script
            cardName = CardName.ExplodingPaws;
            cardType = CardType.Explosive;
            
            base.OnValidate();
        }

        protected override void PlayCard()
        {
            base.PlayCard();
        }
    }
}
