using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Threading;

namespace COMegalab
{

    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("881747A4-6A3A-48A0-A1F4-9E170AC89F5E")]
    public interface IblackjackHandler
    {
        int getPlayerTotal(int playerID);
        void setPlayerState(int playerID, bool isCurrentPlayer);
        void setPlayerState(int playerID, bool isCurrentPlayer, bool isEnough);
        bool[] getPlayerState(int playerID);
        void playerTakeOne(int playerID);
        List<string> getPlayerHand(int playerID);
        string getEndOfRoundState(int playerID);
    }
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("BA0B78EE-F7FB-4681-85E6-3E5BEDCA9D89")]
    [ProgId("COMegalab")]
    public class blackjackHandler : IblackjackHandler
    {
        Deck deck;
        Round round;
        public blackjackHandler()
        {
            deck = new Deck();
            round = new Round(deck);
        }
        public string getEndOfRoundState(int playerID)
        {
            if ((round.players[playerID].total > 21) || (round.players[playerID].total < round.players[2].total))
            {
                return "Вы проиграли.";
            }
            else if (round.players[playerID].total > round.players[2].total)
            {
                return "Вы победили.";
            }
            else if (round.players[playerID].total == round.players[2].total)
            {
                return "Ничья.";
            }
            else return "Вы победили.";
        }
        public List<string> getPlayerHand(int playerID)
        {
            List<string> returnableValue = new List<string>();
            foreach (var item in round.players[playerID].cards)
            {
                returnableValue.Add(item.pathTo);
            }
            return returnableValue;
        }
        public int getPlayerTotal(int playerID)
        {
            return round.players[playerID].total;
        }
        public void setPlayerState(int playerID, bool isCurrentPlayer)
        {
            round.players[playerID].isCurrentPlayer = isCurrentPlayer;
        }
        public void setPlayerState(int playerID, bool isCurrentPlayer, bool isEnough)
        {
            round.players[playerID].isCurrentPlayer=isCurrentPlayer;
            round.players[playerID].isEnough = isEnough;
        }
        public bool[] getPlayerState(int playerID)
        {
            bool[] returnableValue = new bool[2] { round.players[playerID].isCurrentPlayer, round.players[playerID].isEnough };
            return returnableValue;
        }
        public void playerTakeOne(int playerID)
        {
            round.players[playerID].takeCard(ref deck);
        }
    }
}