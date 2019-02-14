using CefSharp;
using CefWpfClient.Helpers;

namespace CefWpfClient.ViewModels
{
    public class WebBrowserViewModel : ObservableObject
    {
        private IWebBrowser m_webBrowser;

        public void Initialize(IWebBrowser webBrowser)
        {
            m_webBrowser = webBrowser;
            m_webBrowser.Load("http://www.google.com");
        }

        public void OnFinishedLoading(LoadingStateChangedEventArgs loadingState)
        {
            if (!loadingState.IsLoading)
            {
                //Hide loading message
            }
        }

        public void OnLoadError(LoadErrorEventArgs loadError)
        {
            //Something went wrong, check load error
        }
    }
}