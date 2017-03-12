using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Services.Maps;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_GeoLocation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Geolocator myGeo;
        Geoposition _pos;

        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        AreaClass myRoom;
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            svPoints.Height = Window.Current.Bounds.Height / 2;
            // if the AreaClass object is null, then create.
            if (myRoom == null)
            {
                myRoom = new UWP_GeoLocation.AreaClass();

            }
        }

        private void elInit_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // get the locations services running
            // get a handle to the geolocator
            // once it's available, add the two events
            // status updates, position changes
            initialiseGeoLocation();

        }

        private async void initialiseGeoLocation()
        {
            var access = await Geolocator.RequestAccessAsync();
            switch (access)
            {
                case GeolocationAccessStatus.Allowed:
                    // set some stuff up now.
                    tblStatus.Text = "Setting up location services";
                    myGeo = new Geolocator();
                    myGeo.StatusChanged += MyGeo_StatusChanged;
                    //myGeo.PositionChanged not needed just now.
                    myGeo.DesiredAccuracy = PositionAccuracy.Default;
                    break;
                case GeolocationAccessStatus.Denied:
                case GeolocationAccessStatus.Unspecified:
                    // ask the user for something here if things go wrong.
                    tblStatus.Text = "Can't access location services";
                    break;
                default:
                    break;
            }
        }

        private async void MyGeo_StatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            // notify the user that something has happened.
            // event is raised in a background thread, so use CoreDispatcher
            // to update the ui
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal,
                () => 
                {
                    #region Switch(args.Status)

                    switch (args.Status)
                    {
                        case PositionStatus.Ready:
                            tblStatus.Text = "All good";
                            break;
                        case PositionStatus.Initializing:
                            tblStatus.Text = "Initialising";
                            break;
                        case PositionStatus.NoData:
                            tblStatus.Text = "No Data";
                            break;
                        case PositionStatus.Disabled:
                            tblStatus.Text = "disabled";
                            break;
                        case PositionStatus.NotInitialized:
                            tblStatus.Text = "Not Initalised";
                            break;
                        case PositionStatus.NotAvailable:
                            tblStatus.Text = "Not Available";
                            break;
                        default:
                            break;
                    } // end switch
                    #endregion
                });

        }

        private async void elSavePosition_Tapped(object sender, TappedRoutedEventArgs e)
        {

            // get the current locations
            try
            {
                // _pos is of type GeoPosition
                // current location
                _pos = await myGeo.GetGeopositionAsync();

                myRoom.addPointToArray(_pos);
                displayPointDetails();
            }
            catch
            {
                tblStatus.Text = "Problem reading location!";
                return;
            }
        }

        private void displayPointDetails()
        {
            // get the current location and show it in the stack panel
            // create three text boxes, put them in a stack panel and then 
            // add to the existing stack panel
            StackPanel sp;
            TextBlock tblTime, tblLong, tbLat;

            sp = new StackPanel();
            sp.Margin = new Windows.UI.Xaml.Thickness(2);

            // text boxes
            tblTime = new TextBlock();
            tblTime.Text = "Time: " + _pos.Coordinate.Timestamp.Date.ToString(); ;

            tbLat = new TextBlock();
            tbLat.FontSize = 32;

            tbLat.Text = "Lat:  " + _pos.Coordinate.Point.Position.Latitude.ToString();

            tblLong = new TextBlock();
            tblLong.FontSize = 32;
            tblLong.Text = "Long: " + _pos.Coordinate.Point.Position.Longitude.ToString();

            sp.Children.Add(tblTime);
            sp.Children.Add(tbLat);
            sp.Children.Add(tblLong);

            // add to the screen
            spLocations.Children.Add(sp);
        }

        private void elCalcArea_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // if the user has not entered 3 points, then error
            if( myRoom.numPoints() < 3)
            {
                // need more points
                tblStatus.Text = "Not enough points taken!";
                return;
            }

            // calculate the area.
            double area = myRoom.areaOfShape("rectangle");
            tblStatus.Text = "Area is " + area.ToString();


        }

        private void elDistance_Tapped(object sender, TappedRoutedEventArgs e)
        {
            double dist = myRoom.distanceAB(0,1);
            tblStatus.Text = "Distance is " + dist.ToString();
        }
    }
}
