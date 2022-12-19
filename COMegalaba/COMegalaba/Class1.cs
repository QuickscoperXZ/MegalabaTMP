using System;
using System.Runtime.InteropServices;

namespace COMegalab
{
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("881747A4-6A3A-48A0-A1F4-9E170AC89F5E")]
    public interface IblackjackHandler
    {
        int handlePlayerState(int playerTotal, int dealerTotal);
    }
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("BA0B78EE-F7FB-4681-85E6-3E5BEDCA9D89")]
    [ProgId("COMegalab")]
    public class blackjackHandler : IblackjackHandler
    {
        public int handlePlayerState(int playerTotal, int dealerTotal)
        {
            if (playerTotal > 21)
            {
                return 0;
            }
            if (dealerTotal > 21)
            {
                return 1;
            }
            if (playerTotal < dealerTotal)
            {
                return 0;
            }
            else if (playerTotal > dealerTotal)
            {
                return 1;
            }
            else
            { return 2; }
        }
    }
}