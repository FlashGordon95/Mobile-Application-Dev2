using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Sensors;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_Accelerometer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // create the Accelerometer variable
        Accelerometer _myAcc;
        DispatcherTimer _timer; // use to move stuff and draw the axes
        private uint _desiredReportInterval;

        public MainPage()
        {
            this.InitializeComponent();
            // when the page is loaded, fire this event.
            this.Loaded += MainPage_Loaded;
            this.KeyDown += new KeyEventHandler(Window_KeyDown);
            Debug.WriteLine("Pressed start");
        }

        private void Window_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            // ... Test for Down key.
            switch (e.Key)
            {
                case VirtualKey.Down:
                    // do something
                    Debug.WriteLine("Pressed d");
                    break;
                case VirtualKey.Up:
                    // do something
                    break;
                case VirtualKey.Left:
                    // do something
                    break;
                case VirtualKey.Right:
                    // do something
                    break;
            
            }
        }

        #region Timers Information
        private void setupTimers()
        {
            if( _timer == null)
            {
                _timer = new DispatcherTimer();
                _timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
                _timer.Tick += _timer_Tick;
            }
        }

        private void _timer_Tick(object sender, object e)
        {
            // move the block in a while,

        }


        #endregion
        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            // check first if there is an accelerometer
            _myAcc = Accelerometer.GetDefault();
            MessageDialog msgDialog = new MessageDialog("Standard Message");
            if (_myAcc == null)
            {
                // tell someone who cares.
                // not there
                msgDialog.Content = "Cheap pc, no accelerometer";
                await msgDialog.ShowAsync();
            }
            else
            {
                // create the event handlers for readings
                // changed and the shaken event.
                _myAcc.ReadingChanged += _myAcc_ReadingChanged;
                _myAcc.Shaken += _myAcc_Shaken;
                // set the report intervals in milliseconds
                uint minReportInterval = _myAcc.MinimumReportInterval;
                /*
                 * compare the min report interval against the requested 
                 * interval of 100 milliseconds
                 * if the minimum possible value is > 100, then use the 
                 * accelerometer min value, otherwise use the requested value
                 * of 100 milliseconds.
                 */
                _desiredReportInterval = minReportInterval > 100 ? minReportInterval : 100;
                _myAcc.ReportInterval = _desiredReportInterval; 
            }
        }

        private async void _myAcc_Shaken(Accelerometer sender, AccelerometerShakenEventArgs args)
        {
            // tell the user not to shake the phone;
            MessageDialog msgDialog = new MessageDialog("that's not a good idea");
            await msgDialog.ShowAsync();
        }

        private async void _myAcc_ReadingChanged(Accelerometer sender, 
            AccelerometerReadingChangedEventArgs args)
        {
            // update the UI with the reading.
            /*
             * The () => {} construct is called a lambda expression
             * This is an anonymous function that can be used to create delegate methods
             * of passed as arguments or returned as the value of a function call.
             * In this case, the Accelerometer thread is asking the UI thread 
             * to update some display information from the readings.
             */
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, 
                () =>
                {
                    // update the UI from here.
                    AccelerometerReading reading = args.Reading;
                    updateUI(reading);
                }
            );

        }

        private void updateUI(AccelerometerReading reading)
        {
            // update the text box values and the axes
            txtX.Text = "X: " + reading.AccelerationX.ToString("0.000");
            txtY.Text = "Y: " + reading.AccelerationY.ToString("0.000");
            txtZ.Text = "Z: " + reading.AccelerationZ.ToString("0.000");

            xLine.X2 = xLine.X1 + reading.AccelerationX * 200;
            yLine.Y2 = yLine.Y1 - reading.AccelerationY * 200;

            zLine.X2 = zLine.X1 - reading.AccelerationZ * 100;
            zLine.Y2 = zLine.Y1 + reading.AccelerationZ * 100;


        }
    }
}
