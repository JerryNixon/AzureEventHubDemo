﻿#pragma checksum "C:\git.repos\AzureEventHubDemo\WindowsClient\Views\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "53D51865AD0C7FBE518C626ABE5746B5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsClient.Views
{
    partial class MainPage : 
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
                    this.ViewModel = (global::WindowsClient.ViewModels.MainPageViewModel)(target);
                }
                break;
            case 2:
                {
                    this.VisualStateGroup = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 3:
                {
                    this.MasterVisualState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 4:
                {
                    this.DetailsVisualState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 5:
                {
                    this.ChatContainer = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 6:
                {
                    this.MainContentContainer = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 7:
                {
                    this.pageHeader = (global::Template10.Controls.PageHeader)(target);
                }
                break;
            case 8:
                {
                    this.OverlayContainer = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 9:
                {
                    this.Image = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 10:
                {
                    this.Phrase = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 11:
                {
                    this.Date = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 12:
                {
                    this.Minute = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 13:
                {
                    this.WebView = (global::Windows.UI.Xaml.Controls.WebView)(target);
                }
                break;
            case 14:
                {
                    this.ProgressBar = (global::Windows.UI.Xaml.Controls.ProgressBar)(target);
                }
                break;
            case 15:
                {
                    global::Windows.UI.Xaml.Controls.RelativePanel element15 = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                    #line 195 "..\..\..\Views\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RelativePanel)element15).PointerEntered += this.Item_PointerEntered;
                    #line 196 "..\..\..\Views\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RelativePanel)element15).PointerExited += this.Item_PointerExited;
                    #line 198 "..\..\..\Views\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.RelativePanel)element15).Tapped += this.Item_Tapped;
                    #line default
                }
                break;
            case 16:
                {
                    this.appBarToggleButton = (global::Windows.UI.Xaml.Controls.AppBarToggleButton)(target);
                }
                break;
            case 17:
                {
                    this.CloseDetailView = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 157 "..\..\..\Views\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)this.CloseDetailView).Tapped += this.Close_Tapped;
                    #line default
                }
                break;
            case 18:
                {
                    this.InputContainer = (global::Windows.UI.Xaml.Controls.RelativePanel)(target);
                }
                break;
            case 19:
                {
                    this.MessageListView = (global::Windows.UI.Xaml.Controls.ListView)(target);
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

