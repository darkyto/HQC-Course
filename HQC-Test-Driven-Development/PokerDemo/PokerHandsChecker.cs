namespace Poker
{
    using System;

    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            var handCards = hand.Cards;

            if (handCards.Count != 5)
            {
                return false;
            }

            for (var i = 0; i < handCards.Count - 1; i++)
            {
                var currCard = handCards[i];
                var nextCard = handCards[i + 1];
                if (currCard.ToString() == nextCard.ToString())
                {
                    return false;
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            var handCards = hand.Cards;

            if (!IsValidHand(hand))
            {
                return false;
            }

            var firstCard = handCards[0];
            var secondCard = handCards[1];
            var thirdCard = handCards[2];
            var fourthCard = handCards[3];
            var fifthCard = handCards[4];

            if (firstCard.Face == secondCard.Face &&
                   firstCard.Face == thirdCard.Face &&
                   firstCard.Face == fourthCard.Face &&
                   firstCard.Face != fifthCard.Face)
            {
                return true;
            }
            else if (firstCard.Face == secondCard.Face &&
                     firstCard.Face == thirdCard.Face &&
                     firstCard.Face != fourthCard.Face &&
                     firstCard.Face == fifthCard.Face)
            {
                return true;
            }
            else if (firstCard.Face != secondCard.Face &&
                     firstCard.Face == thirdCard.Face &&
                     firstCard.Face == fourthCard.Face &&
                     firstCard.Face == fifthCard.Face)
            {
                return true;
            }
            else if (firstCard.Face == secondCard.Face &&
                     firstCard.Face != thirdCard.Face &&
                     firstCard.Face == fourthCard.Face &&
                     firstCard.Face == fifthCard.Face)
            {
                return true;
            }
            else if (secondCard.Face == thirdCard.Face &&
                    secondCard.Face == fourthCard.Face &&
                    secondCard.Face == fifthCard.Face &&
                    secondCard.Face != firstCard.Face)
            {
                return true;
            }
            else if (secondCard.Face != thirdCard.Face &&
                secondCard.Face == fourthCard.Face &&
                secondCard.Face == fifthCard.Face &&
                secondCard.Face == firstCard.Face)
            {
                return true;
            }
            else if (secondCard.Face == thirdCard.Face &&
                secondCard.Face != fourthCard.Face &&
                secondCard.Face == fifthCard.Face &&
                secondCard.Face == firstCard.Face)
            {
                return true;
            }
            else if (secondCard.Face == thirdCard.Face &&
                secondCard.Face == fourthCard.Face &&
                secondCard.Face != fifthCard.Face &&
                secondCard.Face == firstCard.Face)
            {
                return true;
            }
            else if (thirdCard.Face == fourthCard.Face &&
                    thirdCard.Face == fifthCard.Face &&
                    thirdCard.Face != secondCard.Face &&
                    thirdCard.Face == firstCard.Face)
            {
                return true;
            }
            else if (thirdCard.Face == fourthCard.Face &&
                    thirdCard.Face == fifthCard.Face &&
                    thirdCard.Face == secondCard.Face &&
                    thirdCard.Face != firstCard.Face)
            {
                return true;
            }
            else if (thirdCard.Face == fourthCard.Face &&
                    thirdCard.Face != fifthCard.Face &&
                    thirdCard.Face == secondCard.Face &&
                    thirdCard.Face == firstCard.Face)
            {
                return true;
            }
            else if (thirdCard.Face != fourthCard.Face &&
                    thirdCard.Face == fifthCard.Face &&
                    thirdCard.Face == secondCard.Face &&
                    thirdCard.Face == firstCard.Face)
            {
                return true;
            }
            else if (fourthCard.Face != thirdCard.Face &&
                    fourthCard.Face == fifthCard.Face &&
                    fourthCard.Face == secondCard.Face &&
                    fourthCard.Face == firstCard.Face)
            {
                return true;
            }
            else if (fourthCard.Face == thirdCard.Face &&
                    fourthCard.Face != fifthCard.Face &&
                    fourthCard.Face == secondCard.Face &&
                    fourthCard.Face == firstCard.Face)
            {
                return true;
            }
            else if (fourthCard.Face == thirdCard.Face &&
                    fourthCard.Face == fifthCard.Face &&
                    fourthCard.Face != secondCard.Face &&
                    fourthCard.Face == firstCard.Face)
            {
                return true;
            }
            else if (fourthCard.Face == thirdCard.Face &&
                    fourthCard.Face == fifthCard.Face &&
                    fourthCard.Face == secondCard.Face &&
                    fourthCard.Face != firstCard.Face)
            {
                return true;
            }
            else if (fifthCard.Face == fourthCard.Face &&
                    fifthCard.Face == thirdCard.Face &&
                    fifthCard.Face == secondCard.Face &&
                    fifthCard.Face != firstCard.Face)
            {
                return true;
            }
            else if (fifthCard.Face == fourthCard.Face &&
                    fifthCard.Face == thirdCard.Face &&
                    fifthCard.Face != secondCard.Face &&
                    fifthCard.Face == firstCard.Face)
            {
                return true;
            }
            else if (fifthCard.Face == fourthCard.Face &&
                    fifthCard.Face != thirdCard.Face &&
                    fifthCard.Face == secondCard.Face &&
                    fifthCard.Face == firstCard.Face)
            {
                return true;
            }
            else if (fifthCard.Face != fourthCard.Face &&
                    fifthCard.Face == thirdCard.Face &&
                    fifthCard.Face == secondCard.Face &&
                    fifthCard.Face == firstCard.Face)
            {
                return true;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            var handCards = hand.Cards;

            if (!IsValidHand(hand))
            {
                return false;
            }

            for (var i = 0; i < handCards.Count; i += 5)
            {
                var firstCard = handCards[i];
                var secondCard = handCards[i + 1];
                var thirdCard = handCards[i + 2];
                var fourthCard = handCards[i + 3];
                var fifthCard = handCards[i + 4];
                if (firstCard.Suit == secondCard.Suit &&
                    secondCard.Suit == thirdCard.Suit &&
                    thirdCard.Suit == fourthCard.Suit &&
                    fourthCard.Suit == fifthCard.Suit)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}