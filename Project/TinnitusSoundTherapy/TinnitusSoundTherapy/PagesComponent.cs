using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.ApplicationModel.Resources.Core;
using Windows.UI.Xaml.Controls;

namespace TinnitusSoundTherapy
{
    
    public partial class MainPage : Page
    {

        static ResourceLoader res = new ResourceLoader(); // Load in the resources files we are using for users platform
      
        /// <summary>
        /// 
        /// We should localise the names of these pages so everything in the app is localised when we generate machine translations.
        /// </summary>

        List<PageListObject> pages = new List<PageListObject>
        {
            new PageListObject() { Title=res.GetString("homePageTitle-sidemenu"), ClassType=typeof(HomePage)},
            new PageListObject() { Title=res.GetString("soundTherapy-sidemenu"), ClassType=typeof(SoundTherapy)},
            new PageListObject() { Title=res.GetString("whatisTin-sidemenu"), ClassType=typeof(WhatIsTinnitus)},
            new PageListObject() { Title=res.GetString("feedbackPage-sidemenu"), ClassType=typeof(Feedback)}
        };


       
    }

    public class PageListObject
    {
        public string Title { get; set; }
        public Type ClassType { get; set; }
    }
    

}
