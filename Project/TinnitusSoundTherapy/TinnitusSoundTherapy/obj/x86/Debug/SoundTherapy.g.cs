﻿#pragma checksum "C:\Users\Ryan\Desktop\Mobile-Application-Dev2\Project\TinnitusSoundTherapy\TinnitusSoundTherapy\SoundTherapy.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "DB7711B21CF0B678C227F07F1DF50E95"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TinnitusSoundTherapy
{
    partial class SoundTherapy : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.stHeader = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 2:
                {
                    this.playButtonsSP = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3:
                {
                    global::Microsoft.Advertising.WinRT.UI.AdControl element3 = (global::Microsoft.Advertising.WinRT.UI.AdControl)(target);
                    #line 30 "..\..\..\SoundTherapy.xaml"
                    ((global::Microsoft.Advertising.WinRT.UI.AdControl)element3).ErrorOccurred += this.AdControl_ErrorOccurred;
                    #line default
                }
                break;
            case 4:
                {
                    this.Pan = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    #line 71 "..\..\..\SoundTherapy.xaml"
                    ((global::Windows.UI.Xaml.Controls.Slider)this.Pan).ValueChanged += this.Pan_ValueChanged;
                    #line default
                }
                break;
            case 5:
                {
                    this.playButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 56 "..\..\..\SoundTherapy.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.playButton).Click += this.button_Play_Click;
                    #line default
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 58 "..\..\..\SoundTherapy.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.button_Stop_Click;
                    #line default
                }
                break;
            case 7:
                {
                    global::Windows.UI.Xaml.Controls.Button element7 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 61 "..\..\..\SoundTherapy.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element7).Click += this.button_Pause_Click;
                    #line default
                }
                break;
            case 8:
                {
                    global::Windows.UI.Xaml.Controls.Button element8 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 46 "..\..\..\SoundTherapy.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element8).Click += this.changeBeat;
                    #line default
                }
                break;
            case 9:
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 48 "..\..\..\SoundTherapy.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.changeBeat;
                    #line default
                }
                break;
            case 10:
                {
                    global::Windows.UI.Xaml.Controls.Button element10 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 51 "..\..\..\SoundTherapy.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element10).Click += this.changeBeat;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

