using System.Windows;
using MrMeeseeks.ResXToViewModelGenerator;

namespace MrMeeseeks.ResXLocalizationSample
{
    public partial class App
    {
        public App() => InitializeComponent();

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            MainWindow = new MainWindow((ICurrentLocViewModel) Resources["CurrentLocViewModel"]);
            MainWindow.Show();
        }
    }
}