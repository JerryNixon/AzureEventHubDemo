using System;
using System.Linq;
using Template10.Utils;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace WindowsClient.Views
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            Loaded += (s, e) =>
            {
                VisualStateManager.GoToState(this, MasterVisualState.Name, true);
                ScrollMessageListBoxToBottom();
            };
            ViewModel.Messages.CollectionChanged += (s, e) => ScrollMessageListBoxToBottom();
        }

        private void ScrollMessageListBoxToBottom()
        {
            var scrollViewer = XamlUtils.AllChildren<ScrollViewer>(MessageListView).First();
            scrollViewer.ChangeView(null, int.MaxValue, null);
        }

        private void Close_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            // show master/list
            VisualStateManager.GoToState(this, MasterVisualState.Name, true);
            OverlayContainer.DataContext = null;
            WebView.Navigate(new Uri("about:blank"));
        }

        private void Item_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
        {
            // show details
            OverlayContainer.RenderTransformOrigin = new Windows.Foundation.Point(e.GetPosition(this).X / this.ActualWidth, e.GetPosition(this).Y / this.ActualHeight);
            VisualStateManager.GoToState(this, DetailsVisualState.Name, true);
            var item = (sender as FrameworkElement).DataContext as Models.Voice;
            OverlayContainer.DataContext = item;
            WebView.Navigate(item.Url);
        }

        private void Item_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            // hover effect
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Hand, 1);
            (sender as RelativePanel).Background = Colors.Gainsboro.ToSolidColorBrush();
        }

        private void Item_PointerExited(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            // hover effect
            Window.Current.CoreWindow.PointerCursor = new Windows.UI.Core.CoreCursor(Windows.UI.Core.CoreCursorType.Arrow, 1);
            (sender as RelativePanel).Background = Colors.Transparent.ToSolidColorBrush();
        }
    }
}
