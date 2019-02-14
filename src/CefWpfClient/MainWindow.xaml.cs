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
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            DataContext = m_webBrowserViewModel;
        }

        private void OnBrowserInitialized(object sender, DependencyPropertyChangedEventArgs e)
        {
                m_webBrowserViewModel.Initialize(sender as IWebBrowser);
        }

        private void OnFrameLoadEnd(object sender, LoadingStateChangedEventArgs loadingStateChangedEventArgs)
        {
            InvokeExtensions.OnUIThread(() => { m_webBrowserViewModel.OnFinishedLoading(loadingStateChangedEventArgs); });
        }

        private void OnLoadError(object sender, LoadErrorEventArgs e)
        {
            InvokeExtensions.OnUIThread(() => { m_webBrowserViewModel.OnLoadError(e); });
        }
    }
}