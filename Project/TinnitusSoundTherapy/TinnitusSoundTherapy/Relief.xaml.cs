using System;
using System.Collections.Generic;
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
    public sealed partial class Relief : Page
    {
        CoreWindow cw = Window.Current.CoreWindow;

        public Relief()
        {
            this.InitializeComponent();

        }

        

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
            MediaElement audioFile = new MediaElement();
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync("Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("sound.mp3");
            var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
            audioFile.SetSource(stream, file.ContentType);
            audioFile.Play();
        }
    }



        
}
