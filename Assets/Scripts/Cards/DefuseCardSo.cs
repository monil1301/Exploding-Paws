using UnityEngine;

namespace Cards
{
    [CreateAssetMenu(menuName = "Card SO/Defuse Card SO")]
    public class DefuseCardSo: CardSo
    {
        protected override void OnValidate()
        {
            // Set the values directly in the script
            cardName = CardName.Defuse;
            cardType = CardType.Defensive;

            base.OnValidate();
        }

        protected override void PlayCard()
        {
            base.PlayCard();
        }
    }
}
