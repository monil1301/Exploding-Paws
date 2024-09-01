using System.Collections.Generic;

namespace Structs
{
    public struct CardPack
    {
        public CardTheme Theme;
        public readonly Dictionary<CardName, int> CardsInPack;

        public CardPack(CardTheme theme, Dictionary<CardName, int> cardsInPack)
        {
            Theme = theme;
            CardsInPack = cardsInPack;
        }
    }
}
