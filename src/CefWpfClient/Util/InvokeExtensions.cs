using System;
using System.Windows;
using System.Windows.Threading;

namespace CefWpfClient.Util
{
    /// <summary>
    /// Just a utility class to invoke on UI thread.
    /// </summary>
    internal static class InvokeExtensions
    {
        public static void OnUIThread(Action action)
        {
            var dispatcher = GetDispatcher();
            if (dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                dispatcher.BeginInvoke(action);
            }
        }

        private static Dispatcher GetDispatcher()
        {
            return Application.Current != null ? Application.Current.Dispatcher : Dispatcher.CurrentDispatcher;
        }
    }
}