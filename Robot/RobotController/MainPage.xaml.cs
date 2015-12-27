// 

using System;
using System.Diagnostics;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RobotController
{
    /// <summary>An empty page that can be used on its own or navigated to within a Frame.</summary>
    public sealed partial class MainPage : Page
    {
        private bool _isMoving;

        public MainPage()
        {
            InitializeComponent();
        }

        private void HandleKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (_isMoving)
            {
                return;
            }
            Debug.WriteLine("KeyDown:" + e.Key);
            string message = null;
            switch (e.Key)
            {
                case VirtualKey.Up:
                    message = "MOVE FORWARD";
                    break;
                case VirtualKey.Down:
                    message = "MOVE BACK";
                    break;
                case VirtualKey.Left:
                    message = "MOVE LEFT";
                    break;
                case VirtualKey.Right:
                    message = "MOVE RIGHT";
                    break;
                default:
                    break;
            }
            if (message != null)
            {
                SendMessage(message);
                _isMoving = true;
            }
        }

        private void HandleKeyUp(object sender, KeyRoutedEventArgs e)
        {
            Debug.WriteLine("KeyUp:" + e.Key);
            SendMessage("STOP");
            _isMoving = false;
        }

        private void HandleSendButtonClick(object sender, RoutedEventArgs e)
        {
            string message = CommandTextBox.Text;
            SendMessage(message);
        }

        private async void SendMessage(string message)
        {
            try
            {
                Debug.WriteLine("SendMessage: Creating socket");
                using (var socket = new StreamSocket())
                {
                    Debug.WriteLine("SendMessage: Connecting to server");
                    await socket.ConnectAsync(new HostName("192.168.2.21"), "9090");

                    Debug.WriteLine("SendMessage: Connecting to server");
                    var writer = new DataWriter(socket.OutputStream);
                    var reader = new DataReader(socket.InputStream);

                    writer.UnicodeEncoding = UnicodeEncoding.Utf8;
                    writer.WriteString(message);
                    await writer.StoreAsync();
                    await writer.FlushAsync();

                    Debug.WriteLine("SendMessage: sent message: " + message);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}