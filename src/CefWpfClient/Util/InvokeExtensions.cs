using System;
using System.Windows;
using System.Windows.Threading;

namespace CefWpfClient.Util
{
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