// 

using System;
using Windows.Devices.Gpio;

namespace RaspberryPi
{
    public sealed class Led : IDisposable
    {
        private readonly GpioController _gpio = GpioController.GetDefault();
        private GpioPin _pin;

        public Led(int pin)
        {
            _pin = _gpio.OpenPin(pin, GpioSharingMode.Exclusive);
            _pin.SetDriveMode(GpioPinDriveMode.Output);
            _pin.Write(GpioPinValue.Low);
        }

        public bool IsOn { get; private set; }

        public void SetOff()
        {
            _pin.Write(GpioPinValue.Low);
            IsOn = false;
        }

        public void SetOn()
        {
            _pin.Write(GpioPinValue.High);
            IsOn = true;
        }

        public void Dispose()
        {
            _pin?.Dispose();
            _pin = null;
        }
    }
}