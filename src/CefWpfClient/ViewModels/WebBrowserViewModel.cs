using System;
using CefSharp;
using CefWpfClient.Helpers;

namespace CefWpfClient.ViewModels
{
    public class WebBrowserViewModel : ObservableObject, IDisposable
    {
        private IWebBrowser m_webBrowser;

        /// <summary>
        /// Theese events are registered in the code behind of <see cref="MainWindow"/>
        /// </summary>
        public void Initialize(IWebBrowser webBrowser)
        {
            m_webBrowser = webBrowser;
            //A easier way of forcing the browser to load a site is to bind the Address property of ChromiumWebBrowser to a property in this ViewModel
            m_webBrowser.Load("http://www.google.com");
        }

        /// <summary>
        /// Theese events are registered in the code behind of <see cref="MainWindow"/>
        /// </summary>
        public void OnFinishedLoading(LoadingStateChangedEventArgs loadingState)
        {
            if (!loadingState.IsLoading)
            {
                //Hide loading message
            }
        }
        /// <summary>
        /// Theese events are registered in the code behind of <see cref="MainWindow"/>
        /// </summary>
        public void OnLoadError(LoadErrorEventArgs loadError)
        {
            //Something went wrong, check load error
        }

        /// <summary>
        /// Dispose is called in the <see cref="MainWindow.OnClosed"/> 
        /// </summary>
        public void Dispose()
        {
            m_webBrowser.Dispose();
        }
    }
}