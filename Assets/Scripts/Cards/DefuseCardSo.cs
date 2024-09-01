using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card SO/Defuse Card SO")]
    public class DefuseCardSo: CardSo
    {
        private void OnValidate()
        {
            // Set the values directly in the script
            cardName = CardName.Defuse;
            cardType = CardType.Defensive;
        }

        protected override void PlayCard()
        {
            base.PlayCard();
        }
    }
}
