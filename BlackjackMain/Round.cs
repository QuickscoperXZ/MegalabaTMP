using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BlackjackMain
{
    class Player
    {
        public List<Card> playingHand = new List<Card>();
        public int total
        {
            get 
            {
                int returnableValue = 0;
                foreach (var item in playingHand)
                {
                    returnableValue += item.value;
                }
                return returnableValue;
            }
        }
        public int endOfRoundCode;

        public bool isEnough = false;
        public void takeCard(ref Deck deck)
        {
            playingHand.Add(deck.deckContainer.Last());
            deck.deckContainer.Remove(deck.deckContainer.Last());
        }
        public bool isCurrentPlayer = false;
    }

    internal class Round
    {
        public Player[] players = new Player[3];
        public Deck currentDeck;
        private int currentPlayer;
        public int currentPlayerProperty
        {
            get { return currentPlayer; }
            set
            {
                if (value > 1)
                {
                }
                else
                {
                    currentPlayer = value;
                    players[value].isCurrentPlayer = true;
                }
            }
        }
        public Round(Deck currentDeckState)
        {
            players[0] = new Player();
            players[1] = new Player();
            players[2] = new Player();
            currentDeck = currentDeckState;
            reserveCardsDealer();
        }
        void reserveCardsDealer()
        {
            players[2].playingHand.Add(currentDeck.deckContainer[currentDeck.deckContainer.Count - 7]);
            players[2].playingHand.Add(currentDeck.deckContainer[currentDeck.deckContainer.Count - 6]);
            currentDeck.deckContainer.Remove(players[2].playingHand[0]);
            currentDeck.deckContainer.Remove(players[2].playingHand[1]);
        }
    }
}
