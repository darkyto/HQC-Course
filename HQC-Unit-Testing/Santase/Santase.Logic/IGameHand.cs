namespace Santase.Logic
{
    using Santase.Logic.Cards;

    public interface IGameHand
    {
        PlayerPosition Winner { get; }

        Card FirstPlayerCard { get; }

        Announce FirstPlayerAnnounce { get; }

        Card SecondPlayerCard { get; }

        void Start();

        Announce SecondPlayerAnnounce { get; }

        PlayerPosition GameClosedBy { get; }
    }
}