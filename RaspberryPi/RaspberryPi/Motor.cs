// 

using System;
using Windows.Devices.Gpio;

namespace RaspberryPi
{
    // See https://github.com/pimoroni/explorer-hat/blob/master/library/explorerhat.py
    // and https://github.com/gloveboxes/Windows-IoT-Core-Driver-Library/blob/master/Glovebox.IoT.Devices/Actuators/Motor.cs

    public sealed class Motor
    {
        private readonly GpioController _gpio = GpioController.GetDefault();
        private readonly GpioPin _pin1;
        private readonly GpioPin _pin2;

        public Motor(int pin1, int pin2)
        {
            _pin1 = _gpio.OpenPin(pin1);
            _pin2 = _gpio.OpenPin(pin2);

            _pin1.Write(GpioPinValue.Low);
            _pin2.Write(GpioPinValue.Low);

            _pin1.SetDriveMode(GpioPinDriveMode.Output);
            _pin2.SetDriveMode(GpioPinDriveMode.Output);
        }


        public void Start(MotorDirection direction)
        {
            if (direction == MotorDirection.Forward)
            {
                StartForward();
            }
            else
            {
                StartBack();
            }
        }

        public void StartBack()
        {
            _pin1.Write(GpioPinValue.High);
            _pin2.Write(GpioPinValue.Low);
        }

        public void StartForward()
        {
            _pin1.Write(GpioPinValue.Low);
            _pin2.Write(GpioPinValue.High);
        }

        public void Stop()
        {
            _pin1.Write(GpioPinValue.Low);
            _pin2.Write(GpioPinValue.Low);
        }
    }
}