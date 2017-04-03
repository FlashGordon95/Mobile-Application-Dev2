using Microsoft.Advertising.WinRT.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TinnitusSoundTherapy
{
    /// <summary>
    /// A page used to play the sounds. 
    /// Will contain:
    /// A play / pause / stop button that will modify the audio stream
    /// A pan slider to pan sound to either ear
    /// Volume will be handled by system volume with a limiter on max volume.
    /// </summary>
    public sealed partial class SoundTherapy : Page
    {
        CoreWindow cw = Window.Current.CoreWindow;
        MediaElement audioFile = new MediaElement();
        TimeSpan thePosition;

        // 1. get the link to the settings container
        ApplicationDataContainer localSettings =
                    ApplicationData.Current.LocalSettings;

        string selectedBeat;

        public SoundTherapy()
        { 
            this.InitializeComponent();

            DataContext = this;

            try
            {
                // retrieve the pan from a previous session
                // 1. get a link to the localsettings container for this app
                ApplicationDataContainer localSettings =
                            ApplicationData.Current.LocalSettings;

                // 2. check for the key value stored under the name
                //    "selectedPan"
                audioFile.Balance = (double) localSettings.Values["selectedPan"];
                Pan.Value = audioFile.Balance;

                selectedBeat = (string)localSettings.Values["selectedBeat"];
                // 3.  if it is there, then set the SelectedIndex of the pivot page
                //     using the value

                
                //audioFile.Balance = value;
                Debug.WriteLine("After loading storage , balance is " + audioFile.Balance);
                Debug.WriteLine("After loading storage , selected beat is " + selectedBeat);
            }
            catch (Exception exc)
            {
                //We encountered a problem loading the values 
                string localMsg = exc.Message;
                Debug.WriteLine(localMsg);
            }

        }


        /// <summary>
        /// Navagate to the main page again.
        /// Using MediaElement to handle the audio itself.
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }
        /// <summary>
        /// A handler for the play button. When clicked will play sound.
        /// Using MediaElement to handle the audio itself.
        /// </summary>
        private async void button_Play_Click(object sender, RoutedEventArgs e)
        {
            

            switch (audioFile.CurrentState)
            {

                case MediaElementState.Playing:
                    audioFile.Play();
                    break;
                case MediaElementState.Paused:
                    audioFile.Play();
                    break;
                default:

                    /// <summary>
                    /// An Example of local storage. For this we load in an audio file from the system asynchronously
                    /// Then prepare a stream of the data, setting this as the source for our audio file
                    /// Then we play
                    /// 
                    /// POSSIBLE ENCHANCEMENT: Have a button bar with 3-5 different sounds user can select
                    /// On select , stop any playing audio , load in desired track and start playing again
                    /// </summary>
                    /// 
                    if (localSettings.Values["selectedBeat"] == null)
                    {
                        selectedBeat = "beat1.mp3";
                    }
                    if (audioFile.CurrentState != MediaElementState.Playing)
                    {

                        audioFile.Volume = .2;
                        Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
                        Windows.Storage.StorageFile file = await folder.GetFileAsync(selectedBeat);
                        var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        audioFile.SetSource(stream, file.ContentType);

                       
                        // 2. just write the value. This overwrites the value, but in this
                        //    case, that is not a problem.  If it is, then you may want to check 
                        //    whether the value exists or not.
                        localSettings.Values["selectedBeat"] = selectedBeat;
                        Debug.WriteLine("Wrote this balance to local storage " + localSettings.Values["selectedBeat"]);

                    }

                    playSound();
                    break;
            }
        }

        private void playSound()
        {
            audioFile.Play();
        }

        /// <summary>
        /// A handler for the stop button. When clicked will stop the playing sound.
        /// Using MediaElement to handle the audio itself.
        /// </summary>
        private void button_Stop_Click(object sender, RoutedEventArgs e)
        {
            audioFile.Stop();
        }

        /// <summary>
        /// A handler for the pause button. When clicked will pause the sound and retain the position
        /// Using MediaElement to handle the audio itself.
        /// </summary>
        private void button_Pause_Click(object sender, RoutedEventArgs e)
        {
            audioFile.Pause();
        }

        /// <summary>
        /// A handler for the pan slider. 
        /// When the Pan slider is changed we will want to change the sound in accordance to this.
        /// The slider itself has a range of -1 to 1 with a step of 0.1
        /// Using MediaElement.Balance to get and set the pan.
        /// Using MediaElement to handle the audio itself.
        /// </summary>
        private async void Pan_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;

            if (slider != null)
            {

                switch (audioFile.CurrentState)
                {
                    case MediaElementState.Closed:
                        audioFile.Balance = Pan.Value;
                        audioFile.Volume = .1;
                        Debug.WriteLine("Pan value is now" + audioFile.Balance);
                        break;
                    case MediaElementState.Opening:
                        break;
                    case MediaElementState.Buffering:
                        break;
                    case MediaElementState.Playing:
                        thePosition = audioFile.Position; //get old position for audio

                        audioFile.Stop();
                        audioFile = new MediaElement();
                        //we now load up the track again
                        
                    
                        audioFile.Position = thePosition; //restore the position of the track
                        
                        audioFile.Balance = Pan.Value; //pan the media element 
                        audioFile.Volume = .2;
                        Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
                        Windows.Storage.StorageFile file = await folder.GetFileAsync("beat1.mp3");
                        var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        audioFile.SetSource(stream, file.ContentType);
                        audioFile.Play();

                        
                        break;
                    case MediaElementState.Paused:
                        audioFile.Balance = Pan.Value;
                        Debug.WriteLine("Pan value is now" + audioFile.Balance);
                        break;
                    case MediaElementState.Stopped:
                        audioFile.Balance = Pan.Value;
                        Debug.WriteLine("Pan value is now" + audioFile.Balance);
                        break;
                    default:
                        break;
                }
            }
            // 1. get the link to the settings container
            ApplicationDataContainer localSettings =
                        ApplicationData.Current.LocalSettings;
            // 2. just write the value. This overwrites the value, but in this
            //    case, that is not a problem.  If it is, then you may want to check 
            //    whether the value exists or not.
            localSettings.Values["selectedPan"] = audioFile.Balance;
            Debug.WriteLine("Wrote this balance to local storage " + localSettings.Values["selectedPan"]);

        }

        private void changeSound()
        {
            Debug.WriteLine(audioFile.Position);
        }

        private async void changeBeat(object sender, RoutedEventArgs e)
        {
            audioFile.Stop();
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            Random rnd = new Random();
            int beatNo = rnd.Next(1, 4);
            // Prepare the url within the assets folder for the sound
            //  string selectedBeat = "sound" + beatNo + ".mp3";
            //    Windows.Storage.StorageFile file = await folder.GetFileAsync(selectedBeat);
          
                string beatName = "Beat" + beatNo+".mp3";
                Debug.WriteLine("Playing "+beatName);
                Windows.Storage.StorageFile file = await folder.GetFileAsync(beatName);
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                audioFile.SetSource(stream, file.ContentType);

            //  playSound();
            // 1. get the link to the settings container
            ApplicationDataContainer localSettings =
                        ApplicationData.Current.LocalSettings;
            // 2. just write the value. This overwrites the value, but in this
            //    case, that is not a problem.  If it is, then you may want to check 
            //    whether the value exists or not.
            localSettings.Values["selectedBeat"] = beatName;
            Debug.WriteLine("Wrote this balance to local storage " + localSettings.Values["selectedBeat"]);

        }

        private void AdControl_ErrorOccurred(object sender, AdErrorEventArgs e)
        {
            Debug.WriteLine(e.ErrorMessage);
        }
    }
        
}
