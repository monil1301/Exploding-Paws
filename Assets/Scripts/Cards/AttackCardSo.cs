using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card SO/Attack Card SO")]
    public class AttackCardSo: CardSo
    {
        protected override void OnValidate()
        {
            // Set the values directly in the script
            cardName = CardName.Attack;
            cardType = CardType.Action;
            
            base.OnValidate();
        }

        protected override void PlayCard()
        {
            base.PlayCard();
        }
    }
}
