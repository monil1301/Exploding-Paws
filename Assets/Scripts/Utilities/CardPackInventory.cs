using System.Collections.Generic;
using Structs;

namespace Utilities
{
    public static class CardPackInventory
    {
        public static CardPack OriginalCardPack = new (
            theme: CardTheme.Original, // Theme of the pack
            cardsInPack: new Dictionary<CardName, int> // Number of each card in the pack
            {
                { CardName.Attack, 4},
                { CardName.Defuse, 6},
                { CardName.ExplodingPaws, 4},
                { CardName.Favor, 4},
                { CardName.Nope, 4},
                { CardName.SeeTheFuture, 5},
                { CardName.Shuffle, 4},
                { CardName.Skip, 4}
            }
        );
    }
}
