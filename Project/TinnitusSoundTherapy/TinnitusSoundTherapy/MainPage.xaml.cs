using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TinnitusSoundTherapy
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public static MainPage Current;
        public MainPage()
        {
           

            
            this.InitializeComponent();
            PageControl.ItemsSource = pages;
            PageFrame.Navigate(typeof(HomePage));
            Current = this;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SoundTherapy));
        
    }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Splitter.IsPaneOpen = !Splitter.IsPaneOpen;
        }

        /// <summary>
        /// Called whenever the user changes selection in the scenarios list.  This method will navigate to the respective
        /// sample scenario page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            ListBox scenarioListBox = sender as ListBox;
            PageListObject s = scenarioListBox.SelectedItem as PageListObject;
            if (s != null)
            {
                PageFrame.Navigate(s.ClassType);
                if (Window.Current.Bounds.Width < 640)
                {
                    Splitter.IsPaneOpen = false;
                }
            }
        }

        private void NotifyUser(string empty, object statusMessage)
        {
            throw new NotImplementedException();
        }
    }

  
}
