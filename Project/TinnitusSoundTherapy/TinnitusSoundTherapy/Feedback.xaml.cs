using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Email;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class Feedback : Page
    {
        public Feedback()
        {
            this.InitializeComponent();
        }

        private void TextBlock_ContextCanceled(UIElement sender, RoutedEventArgs args)
        {

        }
        /// <summary>
        /// Triggered when the user has submitted feedback.
        /// 
        /// Opens a compose new email window on clients computer with these parameters
        /// Subject : "Feedback for Tinnitus Sound Therapy "
        /// Receipient: My email
        /// Body : The text from the feedback menu.
        /// </summary>
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            EmailMessage email = new EmailMessage(); 
            email.To.Add(new EmailRecipient("ryangordon.dev@gmail.com"));
            email.Subject = "Feedback for Tinnitus Sound Therapy ";
            email.Body = feedbackComment.Text;
            await EmailManager.ShowComposeNewEmailAsync(email);
        }
    }
}
