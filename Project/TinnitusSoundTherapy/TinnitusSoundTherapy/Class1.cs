using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace TinnitusSoundTherapy
{
    public partial class MainPage : Page
    {

        List<PageListObject> pages = new List<PageListObject>
        {
            new PageListObject() { Title="Sound Therapy", ClassType=typeof(Relief)}
        };
    }

    public class PageListObject
    {
        public string Title { get; set; }
        public Type ClassType { get; set; }
    }
}
