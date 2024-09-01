using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card SO/Shuffle Card SO")]
    public class ShuffleCardSo: CardSo
    {
        protected override void OnValidate()
        {
            // Set the values directly in the script
            cardName = CardName.Shuffle;
            cardType = CardType.Action;
            
            base.OnValidate();
        }

        protected override void PlayCard()
        {
            base.PlayCard();
        }
    }
}
