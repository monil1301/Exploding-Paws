using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card SO/See The Future Card SO")]
    public class SeeTheFutureCardSo: CardSo
    {
        protected override void OnValidate()
        {
            // Set the values directly in the script
            cardName = CardName.SeeTheFuture;
            cardType = CardType.Action;
            
            base.OnValidate();
        }

        protected override void PlayCard()
        {
            base.PlayCard();
        }
    }
}
