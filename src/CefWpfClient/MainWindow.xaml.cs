using System.Windows;
using CefSharp;
using CefWpfClient.Util;
using CefWpfClient.ViewModels;

namespace CefWpfClient
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private WebBrowserViewModel m_webBrowserViewModel;

        public MainWindow()
        {
            InitializeComponent();
            m_webBrowserViewModel = new WebBrowserViewModel();
            DataContext = m_webBrowserViewModel;
        }

        /// <summary>
        /// This could definitely be bound directly in XAML with Blend Behaviours
        /// </summary>
        private void OnBrowserInitialized(object sender, DependencyPropertyChangedEventArgs e)
        {
                m_webBrowserViewModel.Initialize(sender as IWebBrowser);
        }
        
        /// <summary>
        /// This could be bound directly in XAML with the use of Blend Behaviours, but we have to invoke it on the UI thread, and I dont want that inside my viewmodels
        /// </summary>
        private void OnFrameLoadEnd(object sender, LoadingStateChangedEventArgs loadingStateChangedEventArgs)
        {
            InvokeExtensions.OnUIThread(() => { m_webBrowserViewModel.OnFinishedLoading(loadingStateChangedEventArgs); });
        }
        
        /// <summary>
        /// This could be bound directly in XAML with the use of Blend Behaviours, but we have to invoke it on the UI thread, and I dont want that inside my viewmodels
        /// </summary>
        private void OnLoadError(object sender, LoadErrorEventArgs e)
        {
            InvokeExtensions.OnUIThread(() => { m_webBrowserViewModel.OnLoadError(e); });
        }
    }
}