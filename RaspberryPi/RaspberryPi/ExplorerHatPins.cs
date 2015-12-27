// 

using System;

namespace RaspberryPi
{
    public enum ExplorerHatPins
    {
        // 5v Tolerant Inputs
        Input1 = 23,
        Input2 = 22,
        Input3 = 24,
        Input4 = 25,

        // Motor, via DRV8833PWP Dual H-Bridge
        Motor1Back = 19,
        Motor1Forward = 20,
        Motor2Back = 21,
        Motor2Forward = 26,

        // Onboard LEDs above 1, 2, 3, 4
        OnboardLed1 = 4,
        OnboardLed2 = 17,
        OnboardLed3 = 27,
        OnboardLed4 = 5,

        //  Outputs via ULN2003A
        Output1 = 6,
        Output2 = 12,
        Output3 = 13,
        Output4 = 16
    }
}