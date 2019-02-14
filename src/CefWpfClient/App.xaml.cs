using System.Windows;

namespace CefWpfClient
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private MainWindow m_mainWindow;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            m_mainWindow = new MainWindow();
            m_mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            m_mainWindow.Dispose();
        }
    }
}