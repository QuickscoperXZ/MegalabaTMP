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
        public void fetchDataFromObject()
        {

        }
        public void putDataToObject()
        {

        }
        public int getPlayerTotal(int playerID)
        {
            return round.players[playerID].total;
        }
        public void getRoundState()
        {

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
        public bool getPlayerState(int playerID)
        {
            return round.players[playerID].isCurrentPlayer;
        }
        public void playerTakeOne(int playerID)
        {
            round.players[playerID].takeCard(ref deck);
        }
    }
}