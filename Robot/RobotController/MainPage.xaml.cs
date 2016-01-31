using System;
using System.Diagnostics;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using RaspberryPi;

namespace RobotController
{
    /// <summary>An empty page that can be used on its own or navigated to within a Frame.</summary>
    public sealed partial class MainPage : Page
    {
        private readonly Robot _robot = new Robot();

        public MainPage()
        {
            Debug.WriteLine("Initialising...");

            InitializeComponent();

            Window.Current.Content.KeyDown += HandleKeyDown;
            Window.Current.Content.KeyUp += HandleKeyUp;

            Debug.WriteLine("Initialised");

        }

        private void HandleKeyDown(object sender, KeyRoutedEventArgs keyRoutedEventArgs)
        {
            Debug.WriteLine("KeyDown key=" + keyRoutedEventArgs.Key);

            if (keyRoutedEventArgs.Key == VirtualKey.Up)
            {
                _robot.MoveForward();
            }
            else if (keyRoutedEventArgs.Key == VirtualKey.Down)
            {
                _robot.MoveBack();
            }
        }

        private void HandleKeyUp(object sender, KeyRoutedEventArgs keyRoutedEventArgs)
        {
            Debug.WriteLine("KeyUp key=" + keyRoutedEventArgs.Key);

            _robot.Stop();
        }
    }
}