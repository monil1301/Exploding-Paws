using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card SO/Skip Card SO")]
    public class SkipCardSo: CardSo
    {
        protected override void OnValidate()
        {
            // Set the values directly in the script
            cardName = CardName.Skip;
            cardType = CardType.Action;
            
            base.OnValidate();
        }

        protected override void PlayCard()
        {
            base.PlayCard();
        }
    }
}
