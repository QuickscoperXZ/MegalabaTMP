using System;
using System.Collections.Generic;
using System.IO;

namespace COMegalab
{
    class Player
    {
        List<Card> cards = new List<Card>();
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
    }

    class Round
    {
        Player[] players = new Player[3] { new Player(), new Player(), new Player() };

    }


    public class Deck
    {
        List<Card> deckContainer = new List<Card>();

        //public Deck(List<string> pths, List<int> val)
        //{
        //    paths = pths;
        //    values = val;
        //}
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
    class Card
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