// 

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using RaspberryPi;
using Buffer = Windows.Storage.Streams.Buffer;

namespace RobotServer
{
    public sealed class RobotServer
    {
        private bool _isMoving;
        private readonly Robot _robot = new Robot();

        private async void HandleListenerConnectionReceived(StreamSocketListener sender, StreamSocketListenerConnectionReceivedEventArgs args)
        {
            try
            {
                IBuffer buffer = new Buffer(10240);
                IBuffer data = await args.Socket.InputStream.ReadAsync(buffer, buffer.Capacity, InputStreamOptions.None);
                var reader = new StreamReader(data.AsStream(), Encoding.UTF8);
                string message = await reader.ReadToEndAsync();
                ProcessMessage(message);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception);
            }
        }

        private void ProcessMessage(string message)
        {
            Debug.WriteLine("ProcessMessage: " + message);

            if (!_isMoving && message.StartsWith("MOVE", StringComparison.OrdinalIgnoreCase))
            {
                if (message.StartsWith("MOVE FORWARD", StringComparison.OrdinalIgnoreCase))
                {
                    _robot.MoveForward();
                }
                if (message.StartsWith("MOVE BACK", StringComparison.OrdinalIgnoreCase))
                {
                    _robot.MoveBack();
                }
                if (message.StartsWith("MOVE RIGHT", StringComparison.OrdinalIgnoreCase))
                {
                    _robot.MoveRight();
                }
                if (message.StartsWith("MOVE LEFT", StringComparison.OrdinalIgnoreCase))
                {
                    _robot.MoveLeft();
                }
                _isMoving = true;
            }
            else
            {
                _robot.Stop();
                _isMoving = false;
            }
        }

        public async void RunServer()
        {
            try
            {
                Debug.WriteLine("Starting Robot server");
                var listener = new StreamSocketListener();
                listener.ConnectionReceived += HandleListenerConnectionReceived;
                await listener.BindServiceNameAsync("9090");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}