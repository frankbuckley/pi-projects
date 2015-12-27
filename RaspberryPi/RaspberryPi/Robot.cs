// 

using System;
using System.Diagnostics;

namespace RaspberryPi
{
    public sealed class Robot
    {
        private readonly ExplorerHat _explorerHat = new ExplorerHat();

        public void MoveBack()
        {
            Debug.WriteLine("Robot: MoveBack");
            _explorerHat.Motor1.Start(MotorDirection.Back);
            _explorerHat.Motor2.Start(MotorDirection.Back);
        }

        public void MoveForward()
        {
            Debug.WriteLine("Robot: MoveForward");
            _explorerHat.Motor1.Start(MotorDirection.Forward);
            _explorerHat.Motor2.Start(MotorDirection.Forward);
        }

        public void MoveLeft()
        {
            Debug.WriteLine("Robot: MoveLeft");
            // _explorerHat.Motor1.Start(MotorDirection.Back);
            _explorerHat.Motor2.Start(MotorDirection.Forward);
        }

        public void MoveRight()
        {
            Debug.WriteLine("Robot: MoveRight");
            _explorerHat.Motor1.Start(MotorDirection.Forward);
            //_explorerHat.Motor2.Start(MotorDirection.Back);
        }

        public void Stop()
        {
            _explorerHat.Motor1.Stop();
            _explorerHat.Motor2.Stop();
        }
    }
}