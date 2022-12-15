using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackMain
{
    class Player
    {
        public List<Card> playingHand = new List<Card>();
        int total
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

        public void takeCard(ref Deck deck)
        {
            playingHand.Add(deck.deckContainer.Last());
            deck.deckContainer.Remove(deck.deckContainer.Last());
        }
    }

    internal class Round
    {
        public Player[] players = new Player[2];
        public Deck currentDeck;
        int currentPlayer;

        public Round(Deck currentDeckState)
        {
            players[1] = new Player();
            players[2] = new Player();
        }
    }
}
