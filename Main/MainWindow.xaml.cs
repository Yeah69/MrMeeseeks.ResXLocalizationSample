using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using MrMeeseeks.ResXToViewModelGenerator;

namespace MrMeeseeks.ResXLocalizationSample
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        private readonly ICurrentLocViewModel _currentLocViewModel;
        private string _inCodeReactiveText;

        public string InCodeReactiveText
        {
            get => _inCodeReactiveText;
            set
            {
                _inCodeReactiveText = value;
                OnPropertyChanged();
            }
        }

        public MainWindow(ICurrentLocViewModel currentLocViewModel)
        {
            _currentLocViewModel = currentLocViewModel;
            InCodeReactiveText = _currentLocViewModel.CurrentLoc.InCodeReactiveText;
            InitializeComponent();
            currentLocViewModel.PropertyChanged += (_, _) =>
                InCodeReactiveText = _currentLocViewModel.CurrentLoc.InCodeReactiveText;
        }

        private void InCodeButton_OnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                this, 
                _currentLocViewModel.CurrentLoc.InCodeOnDemandText,
                _currentLocViewModel.CurrentLoc.InCodeOnDemandTitle);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}