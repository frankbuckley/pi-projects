// 

using System;

namespace RaspberryPi
{
    // See https://github.com/pimoroni/explorer-hat/blob/master/library/explorerhat.py

    public sealed class ExplorerHat
    {
        public ExplorerHat()
        {
            Reset();
        }

        public void Reset()
        {
            Motor1.Stop();
            Motor2.Stop();
            Led1.SetOff();
            Led2.SetOff();
            Led3.SetOff();
            Led4.SetOff();
        }
        public Motor Motor1 { get; } = new Motor((int)ExplorerHatPins.Motor1Forward, (int)ExplorerHatPins.Motor1Back);

        public Motor Motor2 { get; } = new Motor((int)ExplorerHatPins.Motor2Forward, (int)ExplorerHatPins.Motor2Back);

        public Led Led1 { get; } = new Led((int)ExplorerHatPins.OnboardLed1);

        public Led Led2 { get; } = new Led((int)ExplorerHatPins.OnboardLed2);

        public Led Led3 { get; } = new Led((int)ExplorerHatPins.OnboardLed3);

        public Led Led4 { get; } = new Led((int)ExplorerHatPins.OnboardLed4);
    }
}
