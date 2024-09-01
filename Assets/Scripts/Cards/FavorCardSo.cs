using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card SO/Favor Card SO")]
    public class FavorCardSo: CardSo
    {
        protected override void OnValidate()
        {
            // Set the values directly in the script
            cardName = CardName.Favor;
            cardType = CardType.Action;
            
            base.OnValidate();
        }

        protected override void PlayCard()
        {
            base.PlayCard();
        }
    }
}
