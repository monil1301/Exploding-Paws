using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card SO/Attack Card SO")]
    public class AttackCardSo: CardSo
    {
        private void OnValidate()
        {
            // Set the values directly in the script
            cardName = CardName.Attack;
            cardType = CardType.Action;
        }

        protected override void PlayCard()
        {
            base.PlayCard();
        }
    }
}
