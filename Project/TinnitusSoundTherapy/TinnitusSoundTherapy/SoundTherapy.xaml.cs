using Microsoft.Advertising.WinRT.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media;
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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SoundTherapy : Page
    {
        CoreWindow cw = Window.Current.CoreWindow;
        MediaElement audioFile = new MediaElement();
        TimeSpan thePosition;
        MainPage rootPage;

        public SoundTherapy()
        {
            
            this.InitializeComponent();

            DataContext = this;
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
            
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("sound.mp3");
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            audioFile.SetSource(stream, file.ContentType);
          
            
            audioFile.Play();


            


            
        }

        // This is an error handler for the interstitial ad.
        private void OnErrorOccurred(object sender, AdErrorEventArgs e)
        {
           // rootPage.NotifyUser($"An error occurred. {e.ErrorCode}: {e.ErrorMessage}", NotifyType.ErrorMessage);
        }

        // This is an event handler for the ad control. It's invoked when the ad is refreshed.
        private void OnAdRefreshed(object sender, RoutedEventArgs e)
        {
            // We increment the ad count so that the message changes at every refresh.
           // adCount++;
           // rootPage.NotifyUser($"Advertisement #{adCount}", NotifyType.StatusMessage);
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
                        audioFile.Pause();
                        Debug.WriteLine("Media currently plating. Time:" + audioFile.Position);
                        thePosition = audioFile.Position; //get old position for audio
                        audioFile.Balance = Pan.Value; //pan the media element 
                        audioFile.Position = thePosition; //restore the position of the track
                        //we now load up the track again
                        Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
                        Windows.Storage.StorageFile file = await folder.GetFileAsync("sound.mp3");
                        var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                        audioFile.SetSource(stream, file.ContentType);

                        audioFile.Position = thePosition; //restore the position of the track
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
        }

        private void changeSound()
        {
            Debug.WriteLine(audioFile.Position);


        }
    }




        
}
