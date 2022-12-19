﻿using System;
using System.Runtime.InteropServices;

namespace COMegalab
{
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("881747A4-6A3A-48A0-A1F4-9E170AC89F5E")]
    public interface IblackjackHandler
    {
        public static int handlePlayerState(int playerTotal, int dealerTotal)
        {
            return 0;
        }
    }
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("A01782F2-377E-45B8-82F0-090CACB12FBB")]
    [ProgId("COMegalab")]
    public class blackjackHandler : IblackjackHandler
    {
        public static int handlePlayerState(int playerTotal, int dealerTotal)
        {
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