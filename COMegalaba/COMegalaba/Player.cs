using System;
using System.Collections.Generic;
using System.IO;

namespace COMegalab
{
    public class Player
    {
        public List<Card> cards = new List<Card>();
        public int playerID;
        public bool isCurrentPlayer;
        public bool isEnough;
        int total
        {
            get
            {
                int returnableValue = 0;
                foreach (var item in cards)
                {
                    returnableValue += item.valueProp;
                }
                return returnableValue;
            }
        }
        public void takeCard(ref Deck fromDeck)
        {
            cards.Add(fromDeck.deckContainer[fromDeck.deckContainer.Count - 1]);
            fromDeck.deckContainer.RemoveAt(fromDeck.deckContainer.Count-1);
        }
    }

    public class Round
    {
        Deck currentDeck;
        public Player[] players = new Player[3] { new Player(), new Player(), new Player() };
        int currentPlayer;
        public int currentPlayerProperty
        {
            get { return currentPlayer; }
            set 
            {
                currentPlayer = value;
                for (int i =0;i<=3;i++)
                {
                    if (i != value)
                    { players[i].isCurrentPlayer = false; }
                    else
                    { players[currentPlayer].isCurrentPlayer = true; }                
                }
            }
        }
        public Round(Deck currentDeckState)
        {
            currentDeck = currentDeckState;
            reserveCardsDealer();
        }
        void reserveCardsDealer()
        {
            players[2].cards.Add(currentDeck.deckContainer[currentDeck.deckContainer.Count - 7]);
            players[2].cards.Add(currentDeck.deckContainer[currentDeck.deckContainer.Count - 6]);
            currentDeck.deckContainer.Remove(players[2].cards[0]);
            currentDeck.deckContainer.Remove(players[2].cards[1]);
        }
    }


    public class Deck
    {
        public List<Card> deckContainer = new List<Card>();        
        public Deck()
        {
            foreach (var item in new DirectoryInfo(@"C:\Users\Quickscoper\Downloads\playngCards").GetFiles())
            {
                string path = item.FullName;
                int value;
                if (Int32.TryParse(Convert.ToString(item.Name[0]), out value))
                {
                    
                    value = Int32.Parse(Convert.ToString(item.Name[0]));
                }
                else
                {
                    value = 10;
                }

                deckContainer.Add(new Card(path,value));
            }
            shuffle();
        }

        void shuffle()
        {
            Random rng = new Random();
            int n = deckContainer.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = deckContainer[k];
                deckContainer[k] = deckContainer[n];
                deckContainer[n] = value;
            }
        }
    }
    public class Card
    {
        string pathTo;
        int value;
        public int valueProp
        {
            get { return value; }
        }

        public Card(string path, int val)
        {
            value = val;
            pathTo = path;
        }
    }

}