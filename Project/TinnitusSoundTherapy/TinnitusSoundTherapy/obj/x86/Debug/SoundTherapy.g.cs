﻿#pragma checksum "C:\Users\Ryan\Desktop\Mobile-Application-Dev2\Project\TinnitusSoundTherapy\TinnitusSoundTherapy\SoundTherapy.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C1AA8EF479A36B863A9F88384B0AE10C"
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
                    this.backButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 16 "..\..\..\SoundTherapy.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.backButton).Click += this.Button_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.playButtonsSP = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 3:
                {
                    this.Pan = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    #line 42 "..\..\..\SoundTherapy.xaml"
                    ((global::Windows.UI.Xaml.Controls.Slider)this.Pan).ValueChanged += this.Pan_ValueChanged;
                    #line default
                }
                break;
            case 4:
                {
                    this.playButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 27 "..\..\..\SoundTherapy.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.playButton).Click += this.button_Play_Click;
                    #line default
                }
                break;
            case 5:
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 29 "..\..\..\SoundTherapy.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.button_Stop_Click;
                    #line default
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.Button element6 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 32 "..\..\..\SoundTherapy.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element6).Click += this.button_Stop_Click;
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

