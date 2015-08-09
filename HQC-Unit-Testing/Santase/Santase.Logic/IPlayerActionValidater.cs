namespace Santase.Logic
{
    using Santase.Logic.Cards;
    using Santase.Logic.Players;
    using System.Collections.Generic;

    public interface IPlayerActionValidater
    {
        bool IsValid(PlayerAction action, PlayerTurnContext context, IList<Card> playerCards);
    }
}