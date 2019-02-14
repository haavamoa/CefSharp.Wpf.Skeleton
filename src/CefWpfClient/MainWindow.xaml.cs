using System;
using System.Windows;
using CefSharp;
using CefSharp.Wpf;
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
        private ChromiumWebBrowser m_chromiumWebBrowser;

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
                m_chromiumWebBrowser = sender as ChromiumWebBrowser;
                m_webBrowserViewModel.Initialize(sender as IWebBrowser);
        }
        
        /// <summary>
        /// This could be bound directly in XAML with the use of Blend Behaviours, but we have to invoke it on the UI thread, and I dont want that inside my viewmodels
        /// </summary>
        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs loadingStateChangedEventArgs)
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

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            m_webBrowserViewModel.Dispose();
            m_chromiumWebBrowser.IsBrowserInitializedChanged -= OnBrowserInitialized;
            m_chromiumWebBrowser.LoadingStateChanged -= OnLoadingStateChanged;
            m_chromiumWebBrowser.LoadError -= OnLoadError;
        }
    }
}