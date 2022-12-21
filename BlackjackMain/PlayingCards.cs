using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BlackjackMain.Properties;

namespace BlackjackMain
{
    internal class Card
    {
        public string pathTo;
        public int value;       
        public Card(int value,string path)
        {
            this.value = value;
            pathTo = path;
        }
    }
    internal class Deck
    {
        public List<Card> deckContainer = new List<Card>();        
        public Deck()
        {
            foreach (var item in new DirectoryInfo(@"C:\Users\Quickscoper\Downloads\playngCards").GetFiles())
            {
                string path = item.FullName;
                int value;
                if (Int32.TryParse(Convert.ToString(item.Name[0]),out value))
                {
                    Console.WriteLine(item.Name);
                    value = Int32.Parse(Convert.ToString(item.Name[0]));
                }
                else
                {
                    Console.WriteLine(item.Name);
                    value = 10;
                }

                deckContainer.Add(new Card(value, path));
            }
            shuffle();
        }

        void shuffle()
        {
            Random rng = new Random();
            int n = deckContainer.Count();
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
}
