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

            Thread handler = new Thread(delegate ()
            {
                while (round.players[0])
            });
        }
        public void fetchDataFromObject()
        {

        }
        public void putDataToObject()
        {

        }
        public void getPlayerTotal()
        {

        }
        public void getRoundState()
        {

        }
        public void setPlayerState(int playerID, bool isCurrentPlayer)
        {

        }
        public void setPlayerState(int playerID, bool isCurrentPlayer, bool isEnough)
        {

        }
        public void getPlayerState()
        {

        }
        public void playerTake()
        {

        }
    }
}