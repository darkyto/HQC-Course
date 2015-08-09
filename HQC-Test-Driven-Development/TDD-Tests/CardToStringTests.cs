namespace TDD.Card.ToString
{
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    
    [TestClass]
    public class CardToStringTests
    {
        [TestMethod]
        public void TestCardToStringWithValidData()
        {
            var cardFace = new List<CardFace>
            {
                CardFace.Two,
                CardFace.Three,
                CardFace.Four,
                CardFace.Five,
                CardFace.Six,
                CardFace.Seven,
                CardFace.Eight,
                CardFace.Nine,
                CardFace.Ten,
                CardFace.Jack,
                CardFace.Queen,
                CardFace.King,
                CardFace.Ace
            };

            var cardSuit = new List<CardSuit>
            {
                CardSuit.Clubs,
                CardSuit.Diamonds,
                CardSuit.Hearts,
                CardSuit.Spades
            };

            foreach (var face in cardFace)
            {
                foreach (var suit in cardSuit)
                {
                    var card = new Card(face, suit);
                    Assert.AreEqual(string.Format("{0}{1}", face, suit), card.ToString());
                }
            }
        }

        [TestMethod]
        public void TestCardToStringWithInvalidData1()
        {
            const CardFace Face = CardFace.Ace;
            const CardSuit Suit = CardSuit.Diamonds;
            var card = new Card(Face, Suit);
            Assert.AreNotEqual(string.Empty, card.ToString());
        }

        [TestMethod]
        public void TestCardToStringWithInvalidData2()
        {
            const CardFace Face = CardFace.Ace;
            const CardSuit Suit = CardSuit.Diamonds;
            var card = new Card(Face, Suit);
            Assert.AreNotEqual(string.Format("{0} {1}", Face, Suit), card.ToString());
        }

        [TestMethod]
        public void TestCardToStringWithInvalidData3()
        {
            const CardFace Face = CardFace.Ace;
            const CardSuit Suit = CardSuit.Diamonds;
            var card = new Card(Face, Suit);
            Assert.AreNotEqual(string.Format(" {0} {1}", Face, Suit), card.ToString());
        }

        [TestMethod]
        public void TestCardToStringWithInvalidData4()
        {
            const CardFace Face = CardFace.Ace;
            const CardSuit Suit = CardSuit.Diamonds;
            var card = new Card(Face, Suit);
            Assert.AreNotEqual(string.Format("{0} {1} ", Face, Suit), card.ToString());
        }

        [TestMethod]
        public void TestCardToStringWithInvalidData5()
        {
            const CardFace Face = CardFace.Ace;
            const CardSuit Suit = CardSuit.Diamonds;
            var card = new Card(Face, Suit);
            Assert.AreNotEqual(string.Format("{0},{1}", Face, Suit), card.ToString());
        }
    }
}