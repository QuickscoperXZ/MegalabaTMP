using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace COMegalab
{

    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    [Guid("881747A4-6A3A-48A0-A1F4-9E170AC89F5E")]
    public interface IblackjackHandler
    {
        Deck createDeck(List<string> pths, List<int> vals);
    }
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("BA0B78EE-F7FB-4681-85E6-3E5BEDCA9D89")]
    [ProgId("COMegalab")]
    public class blackjackHandler : IblackjackHandler
    {
        public Deck createDeck(List<string> pths, List<int> vals)
        {
            return new Deck(pths, vals);
        }
    }
}